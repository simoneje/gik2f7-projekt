using System;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Backend.Models;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Database
{
    public class DatabaseService : IDatabaseService
    {
        private DatabaseConfig databaseConfig;
        public DatabaseService(DatabaseConfig dbConfig)
        {
            databaseConfig = dbConfig;
        }

        public async Task<bool> StatusIfExists(int id)
        {
            
            using(var con = new SqliteConnection(databaseConfig.Name))
            {
                var result = await con.QueryAsync<int>("SELECT Id FROM Games WHERE Id=@id", new {id});

                if(result.Count() > 0)
                {
                    return true;
                     
                }
                else
                {
                    return false;
                }    
            
            }
        }
        public void Setup()
        {
            using(SqliteConnection connection = new SqliteConnection(databaseConfig.Name))
            {
                var table = connection.Query<string>("SELECT Name FROM sqlite_master WHERE type='table' AND name = 'Games'");
                var tableName = table.FirstOrDefault();
                if(!string.IsNullOrEmpty(tableName) && tableName == "Games")
                {
                    return;
                }
                using(var sr = new StreamReader(databaseConfig.StructureFile)) 
                {
                        var queries = sr.ReadToEnd();
                        connection.Execute(queries);
                }
            }
        }

        public async Task<GameInfo> UpdateGame(GameInfo game)
        {
            using(var con = new SqliteConnection(databaseConfig.Name))
            {
                var status = StatusIfExists(game.Id);
                status.Wait();
                
                if(status.Result)
                {
                    var res = await con.ExecuteAsync("UPDATE Games SET Name=@Name, Description=@Description, Grade=@Grade, Image=@Image WHERE Id=@Id", game);
                    return game;
                }
                throw new InvalidOperationException();
            }
        }
        public async Task<GameInfo> AddGame(GameInfo game)
        {
            

            using(var connection = new SqliteConnection(databaseConfig.Name))
            {
                var res = await connection.ExecuteAsync("INSERT INTO Games (Name, Description, Grade, Image) VALUES (@Name , @Description, @Grade, @Image)", game);                                                                
                var lastInsert = await connection.QueryAsync<GameInfo>("SELECT Id, Name, Description, Grade, Image FROM Games ORDER BY Id DESC");
                return lastInsert.FirstOrDefault<GameInfo>();
            }   
                    
        }
        public async Task<IEnumerable<GameInfo>> Get()
        {
            using(var con = new SqliteConnection(databaseConfig.Name))
            {
                var res = await con.QueryAsync<GameInfo>("SELECT Id, Name, Description, Grade, Image FROM Games ORDER BY Name ASC");
                return res;
            }
        }
        public async Task<GameInfo> Get(int id)
        {
            using(var con = new SqliteConnection(databaseConfig.Name))
            {
                var res = await con.QueryAsync<GameInfo>("SELECT Id, Name, Description, Grade, Image FROM Games WHERE Id =@id" ,new {id});
                GameInfo hej = res.FirstOrDefault<GameInfo>();
                if (hej.Image.Contains("Uploads\\"))
                {
                    return hej;
                }
                else
                {
                    hej.Image = "Uploads\\error.png";
                    return hej;
                }
                //return res.FirstOrDefault<GameInfo>();
            }
        }
        public async Task<bool> RemoveGame(int id)
        {
            using(var connection = new SqliteConnection(databaseConfig.Name))
            {
                var status = StatusIfExists(id);
                status.Wait();
                if(status.Result)
                {
                    var res = await connection.ExecuteAsync("DELETE FROM Games WHERE Id =@id" ,new {id});
                    if(res > -1) 
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
        }        
    }
}
