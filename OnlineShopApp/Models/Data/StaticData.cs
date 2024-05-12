using Microsoft.EntityFrameworkCore;
using OnlineShopApp.DataSource;
using OnlineShopApp.Models;
using System.Collections.ObjectModel;

using System.Windows.Controls;
using System.Windows.Navigation;


namespace OnlineShop.Models.Data
{
    public static class StaticData
    {   
        public static Frame MainContentFrame = new Frame() { NavigationUIVisibility = NavigationUIVisibility.Hidden };

        #region Получение
        #region Категории
        //Получить Категории в пререданном контексте данных
        public static ObservableCollection<Category> GetAllCategories(ApplicationContext db)
        {
            db.Categories.Load();
            return db.Categories.Local.ToObservableCollection();
        }
        #endregion

        #region Покупатели
        //Получить Покупателей в переданном контексте данных
        public static ObservableCollection<Customer> GetAllCustomers(ApplicationContext db)
        {
            db.Customers
                    .Include(_customer => _customer.Orders)
                    .ThenInclude(_order => _order.IdOrderStatusNavigation)

                    .Include(_customer => _customer.Orders)
                    .ThenInclude(_order => _order.IdStoreNavigation)

                    .Include(_customers => _customers.Orders)
                    .ThenInclude(_order => _order.OrderDetails)
                    .ThenInclude(_detail => _detail.IdProductNavigation)
                    .ThenInclude(_product => _product.IdTypeProductNavigation)
                    .Load();
            return db.Customers.Local.ToObservableCollection();
        }
        // Получить Конкретного Покупателя
        public static Customer GetCustomer(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Customers.Any(c => c.IdCustomer == id);
                if (!checkIsExist)
                {
                    return null;
                }
                else
                {
                    return db.Customers
                    .Include(_customer => _customer.Orders)
                    .ThenInclude(_status => _status.IdOrderStatusNavigation)

                    .Include(_customers => _customers.Orders)
                    .ThenInclude(_order => _order.OrderDetails)
                    .ThenInclude(_detail => _detail.IdProductNavigation)
                    .ThenInclude(_product => _product.IdTypeProductNavigation)
                    .FirstOrDefault(e => e.IdCustomer == id);
                }
            }
        }

        public static Customer GetCustomer(string email, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Customers.Any(c => c.EmailCustomer == email && c.PasswordCustomer == password);
                if (!checkIsExist)
                {
                    email = "Не верный Email или Password"; 
                    return null;
                }
                else
                {
                    return db.Customers
                    .Include(_customer => _customer.Orders)
                    .ThenInclude(_order => _order.IdOrderStatusNavigation)

                    .Include(_customer => _customer.Orders)
                    .ThenInclude(_order => _order.IdStoreNavigation)

                    .Include(_customers => _customers.Orders)
                    .ThenInclude(_order => _order.OrderDetails)
                    .ThenInclude(_detail => _detail.IdProductNavigation)
                    .ThenInclude(_product => _product.IdTypeProductNavigation)
                    .FirstOrDefault(e => e.EmailCustomer == email && e.PasswordCustomer == password);
                }
            }
        }
        #endregion

        #region Сотрудники
        //Получить Сотрудников
        public static ObservableCollection<Employee> GetAllEmployees()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Employees
                    .Include(_employees => _employees.IdStoreNavigation)
                    .Load();
                var result = db.Employees.Local.ToObservableCollection();
                return result;
            }
        }

        // Получить Сотрудников в переданном контектсе
        public static ObservableCollection<Employee> GetAllEmployees(ApplicationContext db)
        {
            db.Employees
                .Include(_employees => _employees.IdStoreNavigation)
                .Load();
            return db.Employees.Local.ToObservableCollection();
        }

        // Получить Конкретного Сотрудника
        public static Employee GetEmployee(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Employees.Any(c => c.IdEmployee == id);
                if (!checkIsExist)
                {
                    return null;
                }
                else
                {
                    return db.Employees
                    .Include(_employees => _employees.IdStoreNavigation)
                    .FirstOrDefault(e => e.IdEmployee == id);
                }
            }
        }

        public static Employee GetEmployee(string email, string password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Employees.Any(c => c.EmailEmployee == email && c.PasswordEmployee == password);
                if (!checkIsExist)
                {
                    email = "Не верный Email или Password";
                    return null;
                }
                else
                {
                    return db.Employees
                    .Include(_employees => _employees.IdStoreNavigation)
                    .FirstOrDefault(e => e.EmailEmployee == email && e.PasswordEmployee == password);
                }
            }
        }
        #endregion

        #region Заказы
        // Получить Заказы
        public static ObservableCollection<Order> GetAllOrders(ApplicationContext db)
        {
            db.Orders
                .Include(_order => _order.IdOrderStatusNavigation)
                .Include(_order => _order.IdStoreNavigation)
                .Include(_order => _order.IdCustomerNavigation)
                .Include(_orders => _orders.IdEmployeeNavigation)
                .Include(_order => _order.OrderDetails)
                .ThenInclude(_detail => _detail.IdProductNavigation)
                .ThenInclude(_product => _product.IdTypeProductNavigation)
                .Load();
            return db.Orders.Local.ToObservableCollection();
        }

        // Получить Конкретный Заказ
        public static Order GetOrder(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Orders.Any(_order => _order.IdOrder == id);
                if (!checkIsExist)
                {
                    return null;
                }
                else
                {
                    return db.Orders
                    .Include(_order => _order.IdCustomerNavigation)
                    .Include(_order => _order.OrderDetails)
                    .ThenInclude(_detail => _detail.IdProductNavigation)
                    .ThenInclude(_product => _product.IdTypeProductNavigation)
                    .FirstOrDefault(_order => _order.IdOrder == id);
                }
            }
        }
        #endregion

        #region Статусы Заказа
        //Получить Статусы Заказа
        public static ObservableCollection<OrderStatus> GetAllOrderStatuses(ApplicationContext db)
        {
            db.OrderStatuses
                .Include(_status => _status.Orders)
                .Load();
            return db.OrderStatuses.Local.ToObservableCollection();
        }
        #endregion

        #region Детали Заказов
        //Получить Детали Заказов
        public static ObservableCollection<OrderDetail> GetAllOrderDetails(ApplicationContext db)
        {
            db.OrderDetails
                .Include(_detail => _detail.IdOrderNavigation)
                .Include(_detail => _detail.IdProductNavigation)
                .ThenInclude(_product => _product.IdTypeProductNavigation)
                .Load();
            return db.OrderDetails.Local.ToObservableCollection();
        }
        // Получить Конкретную Деталь Заказа
        public static OrderDetail GetOrderDetail(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.OrderDetails.Any(_orderDetail => _orderDetail.IdDetail == id);
                if (!checkIsExist)
                {
                    return null;
                }
                else
                {
                    return db.OrderDetails
                    .Include(_detail => _detail.IdOrderNavigation)
                    .Include(_detail => _detail.IdProductNavigation)
                    .FirstOrDefault(_order => _order.IdOrder == id);
                }
            }
        }
        #endregion

        #region Продукты
        //Получить Продукты
        public static ObservableCollection<Product> GetAllProducts(ApplicationContext db)
        {
            db.Products
                .Include(_product => _product.IdProviderNavigation)
                .Include(_product => _product.IdTypeProductNavigation)
                .Load();
            return db.Products.Local.ToObservableCollection();
        }
        // Получить Конкретный Продукт
        public static Product GetProduct(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Products.Any(_product => _product.IdProduct == id);
                if (!checkIsExist)
                { 
                    return null;
                }
                else
                {
                    return db.Products
                    .Include(_product => _product.IdProviderNavigation)
                    .Include(_product => _product.IdTypeProductNavigation)
                    .FirstOrDefault(_product => _product.IdProduct == id);
                }
            }
        }
        #endregion

        #region Поставщики 
        //Получить Поставщиков
        public static ObservableCollection<Provider> GetAllProviders(ApplicationContext db)
        {
            db.Providers.Include(_provider => _provider.Products).Load();
            return db.Providers.Local.ToObservableCollection();
        }
        #endregion

        #region Магазины
        //Получить Магазины
        public static ObservableCollection<Store> GetAllStores(ApplicationContext db)
        {
            db.Stores
                .Include(_store => _store.Orders)
                .Include(_store => _store.Employees)
                .Load();
            return db.Stores.Local.ToObservableCollection();
        }
        #endregion

        #region Типы продуктов
        //Получить Типы продуктов
        public static ObservableCollection<TypesProduct> GetAllTypesProducts(ApplicationContext db)
        {
            db.TypesProducts.Include(_type => _type.IdCategoryNavigation).Load();
            return db.TypesProducts.Local.ToObservableCollection();
        }
        #endregion
        #endregion
    }
}
