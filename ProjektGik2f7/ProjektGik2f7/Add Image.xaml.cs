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
using System.Net;

namespace ProjektGik2f7
{
    /// <summary>
    /// Interaction logic for Add_Image.xaml
    /// </summary>
    public partial class Add_Image : Window
    {

        public Add_Image()
        {
            InitializeComponent();
        }
        private void btnChooseFile_Click(object sender, RoutedEventArgs e)
        {
            //****************************POST IMAGE********************************//

            //Reference Kursmaterial av Thomas Brunström


            //********************************-END-***********************************//

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                filename.Text = openFileDialog.FileName;
            }

        }

        private async void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            if (filename.Text == string.Empty)
            {
                MessageBox.Show("You need to choose a file to upload.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    //agerar som ett formulär där man fyller i data
                    using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                    {
                        //****************************POST IMAGE********************************//

                        //Reference Kursmaterial av Thomas Brunström


                        //********************************-END-***********************************//

                        var image = await File.ReadAllBytesAsync(filename.Text);
                        var shortImageName = System.IO.Path.GetFileName(filename.Text);
                        content.Add(new StreamContent(new MemoryStream(image)), "postImage", shortImageName);
                        content.Add(new StringContent((MainWindow.CurrentSelectedID).ToString()), "Id");
                        using (var message = await client.PostAsync("http://localhost:5000/img/", content))
                        {
                            if (message.IsSuccessStatusCode)
                            {
                                MessageBox.Show("New image added.", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("Something went wrong!", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                
                this.Close();
            }
            
        }
    }
}
