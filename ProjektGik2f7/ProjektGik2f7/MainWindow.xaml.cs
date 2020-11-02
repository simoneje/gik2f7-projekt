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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int CurrentSelectedID;
        private List<Game> FullGameList;
        public ObservableCollection<Game> games;
        public ApiMethods apiService;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void FillGameList(ObservableCollection<Game> games)
        {
            gameList.ItemsSource = games;
        }
        public async void ImageHandler(int id)
        {
            //****************************BITMAP IMAGE HANDLER********************************//

            //Reference https://stackoverflow.com/questions/5346727/convert-memory-stream-to-bitmapimage


            //********************************-END-***********************************//
            using (var client = new HttpClient())
            {
                using (var message = await client.GetAsync("http://localhost:5000/img/?id=" + id))
                {
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var input = await message.Content.ReadAsByteArrayAsync();
                        using (var stream = new MemoryStream(input))
                        {
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = stream;
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.EndInit();
                            bitmap.Freeze();
                            imageView.Source = bitmap;

                        }
                    }     
                }
            }
        }

        //****************************-SEARCH LISTVIEW FILTER-************************//

        // Reference https://www.wpf-tutorial.com/listview-control/listview-filtering/
        

        //********************************-END-***********************************//
        
        private bool ListBoxFilter(Game item)
        {
            if (String.IsNullOrEmpty(searchListBox.Text))
                return false;

            else
                return !item.name.Contains(searchListBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void SearchListBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Game g in FullGameList)
            {
                if (!games.Contains(g))
                {
                    games.Add(g);
                }
            }
            //To.List() för att IEnumerable kastar error
            foreach (Game g in games.ToList())
            {
                if (ListBoxFilter(g))
                {
                    games.Remove(g);         
                }            
            }
       
            gameList.ItemsSource = games;
            CollectionViewSource.GetDefaultView(games).Refresh();
        }

        private async void btnLoadList_Click(object sender, RoutedEventArgs e)
        {
            ApiMethods apiService = new ApiMethods();
            games = await apiService.ViewLoadGames();

            FillGameList(games);
            FullGameList = new List<Game>();
            foreach (Game g in games)
            {
                FullGameList.Add(g);
            }
            if (gameList.Items.Count == 0)
            {
                gameList.Visibility = Visibility.Hidden;
                searchListBox.Visibility = Visibility.Hidden;
                gameInfo.Visibility = Visibility.Hidden;
                btnAddImg.Visibility = Visibility.Hidden;
            }
            else
            {
                gameList.Visibility = Visibility.Visible;
                searchListBox.Visibility = Visibility.Visible;
                gameInfo.Visibility = Visibility.Visible;
                btnAddImg.Visibility = Visibility.Visible;
            }
        }

        private void gameList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {        
            var item = (ListBox)sender;
            var show = (Game)item.SelectedItem;
        
            nameInfo.Text = show.name;
            CurrentSelectedID = show.id;
            idInfo.Text = show.id.ToString();
            descInfo.Text = show.description;
            gradeInfo.Text = show.grade.ToString();
            imageView.Source = null;
            ImageHandler(CurrentSelectedID);    
        } 


        private void btnAddImg_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSelectedID != 0)
            {
                Add_Image add_Image = new Add_Image();
                add_Image.Show();
            }
            else
            {
                MessageBox.Show("You need to choose a game from the list first to upload an image.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            comboBoxWindow boxWindow = new comboBoxWindow();
            boxWindow.Show();
        }      
    }
    public class Game
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int grade { get; set; }
        public string image { get; set; }
    }
}
