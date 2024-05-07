using OnlineShopApp.Models;
using System.Windows;
using System.Windows.Controls;

namespace OnlineShopApp.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для EditControl.xaml
    /// </summary>
    public partial class EditControl : UserControl
    {
        public EditControl()
        {
            InitializeComponent();
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("101");

        }
    }
}
