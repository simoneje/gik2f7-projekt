using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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

namespace ProjektGik2f7
{
    /// <summary>
    /// Interaction logic for removeWindow.xaml
    /// </summary>
    public partial class removeWindow : Window
    {
        
        public removeWindow()
        {
            
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {   
            this.Close();
        }

        private async void btnIdRmv_Click(object sender, RoutedEventArgs e)
        {
            int id;
            bool profit = Int32.TryParse(idInput.Text, out id);
            if (profit)
            {
                if (MessageBox.Show("Are you sure you want to remove this game?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            try 
                            {
                                var Response = await client.DeleteAsync("http://localhost:5000/games/" + id);
                                if (Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                                {
                                    MessageBox.Show("You need to choose a valid ID from the current game list", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Game was removed", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                    this.Close();
                                    ApiMethods apiService = new ApiMethods();
                                    MainWindow mainWindow = new MainWindow();
                                    var games = await apiService.ViewLoadGames();
                                    mainWindow.FillGameList(games);

                                }
                            }
                            catch (HttpRequestException)
                            {
                                MessageBox.Show("Server can't be reached, try again later.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);

                            }

                        }
                    }
                }
                else 
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("You need to specify a valid ID", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }
    }
}
