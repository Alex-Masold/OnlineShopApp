using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShopApp.Models;
using System.Collections.ObjectModel;

namespace OnlineShop.ViewModel
{
    public class AdminViewModel : PropertyChange
    {
        #region Категории
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        { 
            get { return categories; }
            set 
            { 
                categories = value; 
                OnPropertyChanged(nameof(Categories));
            }
        }
        #endregion

        #region Типы Продуктов
        private ObservableCollection<TypesProduct> typesProducts;
        public ObservableCollection<TypesProduct> TypesProducts
        {
            get { return typesProducts; }
            set
            {
                typesProducts = value;
                OnPropertyChanged(nameof(TypesProducts));
            }
        }
        #endregion

        #region Сотрудники
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        #endregion

        #region Клиенты
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        #endregion

        #region Статусы Заказа
        private ObservableCollection<OrderStatus> ordersStatuses;
        public ObservableCollection<OrderStatus> OrdersStatuses
        {
            get { return ordersStatuses; }
            set
            {
                ordersStatuses = value;
                OnPropertyChanged(nameof(OrdersStatuses));
            }
        }
        #endregion

        #region Заказы
        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
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
        private ObservableCollection<OrderDetail> orderDetails;
        public ObservableCollection<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set
            {
                orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }
        #endregion

        #region Поставщики
        private ObservableCollection<Provider> providers;
        //private ObservableCollection<Provider> providers;
        public ObservableCollection<Provider> Providers
        {
            get { return providers; }
            set
            {
                providers = value;
                OnPropertyChanged(nameof(Providers));
            }
        }
        #endregion

        #region Продукты
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        #endregion

        #region Магазины
        private ObservableCollection<Store> stores;
        //private ObservableCollection<Store> stores;
        public ObservableCollection<Store> Stores
        {
            get { return stores; }
            set
            {
                stores = value;
                OnPropertyChanged(nameof(Stores));
            }
        }
        #endregion

        private object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        private RelayCommand selectionChangedTypeProduct;
        public RelayCommand SelectionChangedTypeProduct
        {
            get
            {
                return selectionChangedTypeProduct ?? (selectionChangedTypeProduct = new RelayCommand(obj =>
                {
                    
                        
                }));
            }
        }

        public AdminViewModel()
        {
            TypesProducts = StaticData.GetAllTypesProducts();

            Categories =    StaticData.GetAllCategories();

            Customers =     StaticData.GetAllCustomers();

            Employees =     StaticData.GetAllEmployees();

            Orders =        StaticData.GetAllOrders();

            OrdersStatuses = StaticData.GetAllOrderStatuses();

            OrderDetails =  StaticData.GetAllOrderDetails();

            Products =      StaticData.GetAllProducts();

            Providers =     StaticData.GetAllProviders();

            Stores =        StaticData.GetAllStores();
        }
    } 
}
