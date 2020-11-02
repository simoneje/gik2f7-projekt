using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ProjektGik2f7
{
    /// <summary>
    /// Interaction logic for addGame.xaml
    /// </summary>
    public partial class addGame : Window
    {
        public addGame()
        {
            InitializeComponent();
        }
        void ItemClear()
        {
            gNameInput.Clear();
            gDescInput.Clear();
            gradeSlider.Value = 1;
        }
        private async void addGame_Click(object sender, RoutedEventArgs e)
        {
            if (gNameInput.Text != String.Empty && gDescInput.Text != String.Empty)
            {
                Game game = new Game()
                {
                    name = gNameInput.Text,
                    description = gDescInput.Text,
                    grade = (int)gradeSlider.Value,
                };

                string GameData = JsonSerializer.Serialize(game);
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var Data = new StringContent(GameData, Encoding.UTF8, "application/json");
                        await client.PostAsync("http://localhost:5000/games", Data);
                        MessageBox.Show("New game added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        ItemClear();
                    }
                    catch (HttpRequestException)
                    {
                        MessageBox.Show("Server can't be reached, try again later.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                }
                
            }
            else
            {
                MessageBox.Show("You need to fill all fields to add a new game.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
