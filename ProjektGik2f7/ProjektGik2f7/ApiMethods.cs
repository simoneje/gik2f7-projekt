using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjektGik2f7
{
    public class ApiMethods
    {
        
        public async Task<ObservableCollection<Game>> ViewLoadGames()
        {
            var games = new ObservableCollection<Game>();
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync("http://localhost:5000/games");
                var ResponseContent = await response.Content.ReadAsStringAsync();
                var JsonContent = JsonSerializer.Deserialize<IEnumerable<Game>>(ResponseContent);

                foreach (var g in JsonContent)
                {
                    games.Add(g);

                }  
                
                
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Server can't be reached, try again later.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }       

            return games;
        }

    }
}
