using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.Database;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.ComponentModel;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("games")]
    public class GameInfoController : ControllerBase
    {

        private readonly IDatabaseService dbServices;
        private readonly IGameRepository gameRepository;
        private readonly IImageRepository imageRepository;
        private readonly IWebHostEnvironment env;
        
        /**
        * To use IGameRepository, we need to tell dotnet to use dependency injection
        * to inject the repositories we need. 
        * just like we inject IWebHostEnvironment IHostEnv in the constructor right now.
        */
        public GameInfoController(IWebHostEnvironment IHostEnv, IGameRepository repo, IDatabaseService dbs, IImageRepository imgRp)
        {
            env = IHostEnv;
            gameRepository = repo;
            dbServices = dbs;
            imageRepository = imgRp;

        }
        
        [HttpPost]
        public async Task<GameInfo> AddGame(GameInfo newGame, [FromForm] PostGameImage GameInfo)
        {
            return await gameRepository.Add(newGame);
            
        }
        [HttpDelete("{id}")]
        public async Task<StatusCodeResult> Delete(int id)
        {
            var remove = await gameRepository.Delete(id);
            
            if(remove)
            {
                StatusCodeResult response = new StatusCodeResult(200);
                return response;
            }
            else
            {
                StatusCodeResult response = new StatusCodeResult(404);
                return response;
            }
            
            
        }
        [HttpGet("{id}")]
        public async Task<GameInfo> Get(int Id)
        {
            return await gameRepository.Get(Id);
        }
        [HttpGet]
        public async Task<IEnumerable<GameInfo>> Get()
        {
            return await gameRepository.Get();
        }
        [HttpPut("/update")]
        public async Task<GameInfo> Update(GameInfo game)
        {
            return await gameRepository.Update(game);
        }



        //IGameRepository is a repo to handle game information,
        //The usual CRUD operations is awailable

        //IImageRepository is a repo to handle upload and fetching
        //image from the api.

        //To recieve a image from post we can use FromForm
        //PostGameImage is defined in Models/GameInfo.cs
        [HttpPost("/img")]
        public async Task<GameInfo> AddGameWithImage([FromForm] PostGameImage GameInfo)
        {
            return await imageRepository.SaveImage(GameInfo.Id, GameInfo.PostImage);
        }
        
        //To send a image as response we can return a PhysicaFile
        [HttpGet("/img")]
        public async Task<IActionResult> GetImage(int Id)
        {
            var k = await imageRepository.GetImage(Id);
            return PhysicalFile(k.ImgSrc , k.ImgType);
        }
    }
}
