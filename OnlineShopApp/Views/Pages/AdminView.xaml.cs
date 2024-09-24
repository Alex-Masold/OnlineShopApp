using OnlineShop.ViewModel;
using OnlineShopApp.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace OnlineShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : Page
    {

        public AdminView()
        {
            InitializeComponent();
            AdminViewModel viewModel = new AdminViewModel(Notification);
            DataContext = viewModel;
        }
    }
}
