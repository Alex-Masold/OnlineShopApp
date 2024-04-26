using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.Data;
using OnlineShopApp.DataSource;
using OnlineShopApp.Models;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OnlineShop.Models.Data
{
    public static class StaticData
    {   
        public static Frame MainContentFrame = new Frame() { NavigationUIVisibility = NavigationUIVisibility.Hidden };

        #region Получение
        //Получить Категории
        public static List<Category> GetAllCategories()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Categories
                    .Include(_category => _category.TypesProducts)
                    .ToList();
                return result;
            }
        }

        //Получить Покупателей
        public static List<Customer> GetAllCustomers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Customers
                    .Include(_customer => _customer.Orders)
                    .ToList();
                return result;
            }
        }

        //Получить Сотрудников
        public static List<Employee> GetAllEmployees()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Employees
                    .Include(_employees => _employees.Orders)
                    .Include(_employees => _employees.IdStoreNavigation)
                    .ToList();
                return result;
            }
        }

        //Получить Заказы
        public static List<Order> GetAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Orders
                    .Include(_order => _order.IdCustomerNavigation)
                    .Include(_order => _order.IdEmployeeNavigation)
                    .Include(_order => _order.OrderDetails)
                    .ToList();
                return result;
            }
        }

        //Получить Детали Заказов
        public static List<OrderDetail> GetAllOrderDetails()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.OrderDetails
                    .Include(_detail => _detail.IdOrderNavigation)
                    .Include(_detail => _detail.IdProductNavigation)
                    .ToList();
                return result;
            }
        }

        //Получить Продукты
        public static List<Product> GetAllProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Products
                    .Include(_product => _product.IdProviderNavigation)
                    .Include(_product => _product.IdTypeProductNavigation)
                    .ToList();
                return result;
            }
        }

        //Получить Поставщиков
        public static List<Provider> GetAllProviders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Providers
                    .Include(_proveder => _proveder.Products)
                    .ToList();
                return result;
            }
        }

        //Получить Магазины
        public static List<Store> GetAllStores()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Stores
                    .Include(_store => _store.Employees)
                    .ToList();
                return result;
            }
        }

        //Получить Типы продуктов
        public static List<TypesProduct> GetAllTypesProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.TypesProducts
                    .Include(_type => _type.IdCategoryNavigation)
                    .ToList();
                return result;
            }
        }
        #endregion

        #region Создание 
        //создать категорию
        //public static string CreateCategory(string name)
        //{
        //string result = "Уже существует";
        //using (ApplicationContext db = new ApplicationContext())
        //{
        //    //Проверка на существование
        //    bool checkIsExist = db.Categories.Any(el => el.NameCategory == name);
        //    if (!checkIsExist)
        //    {
        //        Category newCategory = new Category { NameCategory = name };
        //        db.Categories.Add(newCategory);
        //        db.SaveChanges();
        //        result = "Сделано";
        //    }
        //    return result;
        //}
        //}

        //создать Покупателя
        //public static string CreateCustomer(string name, string family, string mail)
        //{
        //string email = $"{name}.{family}@{mail}";
        //string result = "Уже существуеь";
        //using (ApplicationContext db = new ApplicationContext())
        //{
        //    bool checkIsExist = db.Customers.Any(el => (el.NameCustomer == name) && (el.FamilyCustomer == family) && (el.EmailCustomer == email));
        //    if (!checkIsExist)
        //    {
        //        Customer newCustomer = new Customer { NameCustomer = name, FamilyCustomer = family, EmailCustomer = email };
        //        db.Customers.Add(newCustomer);
        //        db.SaveChanges();
        //        result = "Сделано";
        //    }
        //    return result;
        //}
        //}

        //Создать Сотрудника
        //public static string CreateEmployee(string name, string family, string mail, int idStore)
        //{

        //string email = $"{name}.{family}@{mail}";
        //string result = "Уже существуеь";
        //using (ApplicationContext db = new ApplicationContext())
        //{
        //    bool checkIsExist = db.Employees.Any(el =>
        //                                        (el.NameEmployee == name) &&
        //                                        (el.FamilyEmployee == family) &&
        //                                        (el.EmailEmployee == email) &&
        //                                        (el.IdStore == idStore));
        //    if (!checkIsExist)
        //    {
        //        Employee newEmployee = new Employee
        //        {
        //            NameEmployee = name,
        //            FamilyEmployee = family,
        //            EmailEmployee = email,
        //            IdStore = idStore
        //        };
        //        db.Employees.Add(newEmployee);
        //        db.SaveChanges();
        //        result = "Сделано";
        //    }
        //    return result;
        //}
        //}

        //Создать Заказ

        //Создать Детали Заказа

        //Создать Продукт

        //Создать Поставщика

        //Создать Магазин

        //Создать Тип продукта
        #endregion
    }
}
