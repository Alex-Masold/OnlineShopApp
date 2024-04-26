using OnlineShop.ViewModel;
using OnlineShopApp.Models;
using System.Windows.Controls;

namespace OnlineShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Page
    {
        public EmployeeView(Employee employee)
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel(employee);

        }
    }
}
