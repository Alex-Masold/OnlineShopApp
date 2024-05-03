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
        //Получить Категории
        public static ObservableCollection<Category> GetAllCategories()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Categories.Load();
                var result = db.Categories.Local.ToObservableCollection();
                return result;
            }
        }

        //Получить Покупателей
        public static ObservableCollection<Customer> GetAllCustomers()
        {
            using (ApplicationContext db = new ApplicationContext())
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
                var result = db.Customers.Local.ToObservableCollection();
                return result;
            }
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

        // Получить Заказы
        public static ObservableCollection<Order> GetAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders
                    .Include(_order => _order.IdCustomerNavigation)
                    .Include(_orders => _orders.IdEmployeeNavigation)
                    .Include(_order => _order.OrderDetails)
                    .ThenInclude(_detail => _detail.IdProductNavigation)
                    .ThenInclude(_product => _product.IdTypeProductNavigation)
                    .Load();
                var result = db.Orders.Local.ToObservableCollection();
                return result;
            }
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

        //Получить Статусы Заказа
        public static ObservableCollection<OrderStatus> GetAllOrderStatuses()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.OrderStatuses
                    .Include(_status => _status.Orders)
                    .Load();
                var result = db.OrderStatuses.Local.ToObservableCollection();
                return result;
            }
        }

        //Получить Детали Заказов
        public static ObservableCollection<OrderDetail> GetAllOrderDetails()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.OrderDetails
                    .Include(_detail => _detail.IdOrderNavigation)
                    .Include(_detail => _detail.IdProductNavigation)
                    .Load();
                var result = db.OrderDetails.Local.ToObservableCollection();
                return result;
            }
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

        //Получить Продукты
        public static ObservableCollection<Product> GetAllProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products
                    .Include(_product => _product.IdProviderNavigation)
                    .Include(_product => _product.IdTypeProductNavigation)
                    .Load();
                var result = db.Products.Local.ToObservableCollection();
                return result;
            }
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

        //Получить Поставщиков
        public static ObservableCollection<Provider> GetAllProviders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Providers.Include(_provider => _provider.Products).Load();
                var result = db.Providers.Local.ToObservableCollection();
                return result;
            }
        }

        //Получить Магазины
        public static ObservableCollection<Store> GetAllStores()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Stores
                    .Include(_store => _store.Orders)
                    .Include(_store => _store.Employees)
                    .Load();
                var result = db.Stores.Local.ToObservableCollection();
                return result;
            }
        }

        //Получить Типы продуктов
        public static ObservableCollection<TypesProduct> GetAllTypesProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.TypesProducts.Include(_type => _type.IdCategoryNavigation).Load();
                var result = db.TypesProducts.Local.ToObservableCollection();
                return result;
            }
        }
        #endregion

        #region Создание 
        //создать категорию
        public static string CreateCategory(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //Проверка на существование
                bool checkIsExist = db.Categories.Any(el => el.NameCategory == name);
                if (!checkIsExist)
                {
                    Category newCategory = new Category { NameCategory = name };
                    db.Categories.Add(newCategory);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }

        //создать Покупателя
        public static string CreateCustomer(string name, string family, string mail)
        {
            string email = $"{name}.{family}@{mail}";
            string result = "Уже существуеь";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Customers.Any(el => (el.NameCustomer == name) && (el.FamilyCustomer == family) && (el.EmailCustomer == email));
                if (!checkIsExist)
                {
                    Customer newCustomer = new Customer { NameCustomer = name, FamilyCustomer = family, EmailCustomer = email };
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }

        //Создать Сотрудника
        public static string CreateEmployee(string name, string family, string mail, int idStore)
        {

            string email = $"{name}.{family}@{mail}";
            string result = "Уже существуеь";
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Employees.Any(el =>
                                                    (el.NameEmployee == name) &&
                                                    (el.FamilyEmployee == family) &&
                                                    (el.EmailEmployee == email) &&
                                                    (el.IdStore == idStore));
                if (!checkIsExist)
                {
                    Employee newEmployee = new Employee
                    {
                        NameEmployee = name,
                        FamilyEmployee = family,
                        EmailEmployee = email,
                        IdStore = idStore
                    };
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    result = "Сделано";
                }
                return result;
            }
        }

        //Создать Заказ
        public static void CreateOrder(Order _order)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                db.Orders.Add(_order);
                db.SaveChanges();
            }
        }

         //Создать Детали Заказа
        public static OrderDetail CreateOrderDetail(Order order, Product product)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                OrderDetail newOrderDetail = new OrderDetail
                {
                    IdOrderNavigation = order,
                    IdOrder = order.IdOrder,
                    IdProductNavigation = product,
                    IdProduct = product.IdProduct

                };
                db.OrderDetails.Add(newOrderDetail);
                db.SaveChanges();
                return newOrderDetail;
            }

        }

            //Создать Продукт

            //Создать Поставщика

            //Создать Магазин

            //Создать Тип продукта
            #endregion
        }
    }
