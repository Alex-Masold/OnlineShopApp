using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShopApp.Models;

namespace OnlineShop.ViewModel
{
    public class AdminViewModel : PropertyChange
    {
        #region Типы Продуктов
        private List<TypesProduct> typesProducts;
        //private ObservableCollection<TypesProduct> typesProducts;
        public List<TypesProduct> TypesProducts
        {
            get { return typesProducts; }
            set
            {
                typesProducts = value;
                OnPropertyChanged(nameof(TypesProducts));
            }
        }
        #endregion

        #region Категории
        private List<Category> categories;
        //private ObservableCollection<Category> categories;
        public List<Category> Categories
        { 
            get { return categories; }
            set 
            { 
                categories = value; 
                OnPropertyChanged(nameof(Categories));
            }
        }
        #endregion

        #region Клиенты
        private List<Customer> customers;
        //private ObservableCollection<Customer> customers;
        public List<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        #endregion

        #region Сотрудники
        private List<Employee> employees;
        //private ObservableCollection<Employee> employees;
        public List<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        #endregion

        #region Заказы
        private List<Order> orders;
        //private ObservableCollection<Order> orders;
        public List<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        #endregion

        #region Детали Заказа
        private List<OrderDetail> orderDetails;
        //private ObservableCollection<OrderDetail> orderDetails;
        public List<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set
            {
                orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }
        #endregion

        #region Продукты
        private List<Product> products;
        //private ObservableCollection<Product> products;
        public List<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        #endregion

        #region Поставщики
        private List<Provider> providers;
        //private ObservableCollection<Provider> providers;
        public List<Provider> Providers
        {
            get { return providers; }
            set
            {
                providers = value;
                OnPropertyChanged(nameof(Providers));
            }
        }
        #endregion

        #region Магазины
        private List<Store> stores;
        //private ObservableCollection<Store> stores;
        public List<Store> Stores
        {
            get { return stores; }
            set
            {
                stores = value;
                OnPropertyChanged(nameof(Stores));
            }
        }
        #endregion



        public AdminViewModel()
        {
            TypesProducts = StaticData.GetAllTypesProducts();

            Categories =    StaticData.GetAllCategories();

            Customers =     StaticData.GetAllCustomers();

            Employees =     StaticData.GetAllEmployees();

            Orders =        StaticData.GetAllOrders();

            OrderDetails =  StaticData.GetAllOrderDetails();

            Products =      StaticData.GetAllProducts();

            Providers =     StaticData.GetAllProviders();

            Stores =        StaticData.GetAllStores();
        }
    } 
}
