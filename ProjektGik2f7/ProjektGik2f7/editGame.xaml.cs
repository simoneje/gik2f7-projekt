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
    /// Interaction logic for editGame.xaml
    /// </summary>
    public partial class editGame : Window
    {
        private ApiMethods apiService;
        public editGame()
        {
            InitializeComponent();
        }

        private async void editGame1_Click(object sender, RoutedEventArgs e)
        {
            int idInput;
            bool profit = Int32.TryParse(idEditInput.Text, out idInput);
            if (profit)
            {
                if (MessageBox.Show("Are you sure you want to edit this game?", "Save?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Game game = new Game()
                    {
                        id = idInput,
                        name = gNameEditInput.Text,
                        description = gDescEditInput.Text,
                        grade = (int)gradeSliderEdit.Value
                    };

                    string GameData = JsonSerializer.Serialize(game);
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            var Data = new StringContent(GameData, Encoding.UTF8, "application/json");
                            var response = await client.PutAsync("http://localhost:5000/update", Data);
                            if (!response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("You need to specify a valid ID", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Game was edited", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                            }
                        }
                        catch (HttpRequestException)
                        {
                            MessageBox.Show("Server can't be reached, try again later.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }   
            }
            else 
            {
                MessageBox.Show("You need to specify an ID", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }                
        }
    }
}
