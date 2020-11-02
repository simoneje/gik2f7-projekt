using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektGik2f7
{
    /// <summary>
    /// Interaction logic for comboBoxWindow.xaml
    /// </summary>
    public partial class comboBoxWindow : Window
    {
        
        public comboBoxWindow()
        {
            InitializeComponent();
        }
        public void ComboBoxSelectionAddGame()
        {
            addGame window1 = new addGame();
            window1.Show();
            this.Close();
        }
        public void ComboBoxSelectionRemoveGame()
        {
            
            removeWindow window2 = new removeWindow();
            window2.Show();
            this.Close();
        }
        public void ComboBoxSelectionEditGame()
        {
            editGame window3 = new editGame();
            window3.Show();
            this.Close();
        }


        private void comboOKbtn_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = (ComboBoxItem)cmbOptions.SelectedItem;
            var optionContent = (TextBlock)menuItem.Content;
            string menuChoise = optionContent.Text;
            
            if (menuChoise.Equals("Add new game"))
            {
                ComboBoxSelectionAddGame();
            }
            else if (menuChoise.Equals("Remove game"))
            {
                ComboBoxSelectionRemoveGame();
            }
            else if (menuChoise.Equals("Edit game info"))
            {
                ComboBoxSelectionEditGame();
            }
            else
            {
                MessageBox.Show("You need to choose an option from the list.", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
