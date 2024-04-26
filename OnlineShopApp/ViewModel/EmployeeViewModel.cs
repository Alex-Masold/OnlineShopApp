using OnlineShop.Models.Base;
using OnlineShopApp.Models;

namespace OnlineShop.ViewModel
{
    public class EmployeeViewModel : PropertyChange
    {
        private Employee employee;
        public Employee Employee {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged(nameof(Employee));
            } 
        }

        public EmployeeViewModel(Employee employee)
        {
            this.employee = employee;
        }
    }
}
