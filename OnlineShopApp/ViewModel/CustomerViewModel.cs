using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShopApp.Models;

namespace OnlineShop.ViewModel
{
    public class CustomerViewModel : PropertyChange
    {
        private List<OrderDetail> orderDetails = StaticData.GetAllOrderDetails();
        private Customer customer;
        public Customer Customer { 
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        public CustomerViewModel(Customer customer)
        {
            this.customer = customer;
        }
    }
}
