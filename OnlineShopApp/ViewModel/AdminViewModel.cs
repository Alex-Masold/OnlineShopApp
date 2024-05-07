using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShopApp.DataSource;
using OnlineShopApp.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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

        private string oldString;
        private int oldInt;
        private double oldDouble;

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

        private void Change(string newVersion)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newVersion == oldString)
                {
                    MessageBox.Show("Изменений нет");
                }
                else
                {
                    MessageBox.Show($"{oldString} -> {newVersion}");
                    db.Entry(SelectedItem).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
            }
        }
        private void Change(int newVersion)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newVersion == oldInt)
                {
                    MessageBox.Show("Изменений нет");
                }
                else
                {
                    MessageBox.Show($"{oldString} -> {newVersion}");
                    db.Entry(SelectedItem).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
        }
        private void Change(double newVersion)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (newVersion == oldDouble)
                {
                    MessageBox.Show("Изменений нет");
                }
                else
                {
                    MessageBox.Show($"{oldString} -> {newVersion}");
                    db.Entry(SelectedItem).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
        }
        private void Change()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Entry(SelectedItem).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Test(string newVersion)
        {
            if (newVersion == oldString)
            {
                MessageBox.Show("Изменений нет");
            }
            else
            {
                MessageBox.Show($"{oldString} -> {newVersion}");
            }

        }
        public void Test(int newVersion)
        {
            if (newVersion == oldInt)
            {
                MessageBox.Show("Изменений нет");
            }
            else
            {
                MessageBox.Show($"{oldInt} -> {newVersion}");
            }

        }
        public void Test(double newVersion)
        {
            if (newVersion == oldDouble)
            {
                MessageBox.Show("Изменений нет");
            }
            else
            {
                MessageBox.Show($"{oldDouble} -> {newVersion}");
            }

        }

        private RelayCommand gotFocusCommand;
        public RelayCommand GotFocusCommand
        {
            get
            {
                return gotFocusCommand ?? (gotFocusCommand = new RelayCommand(obj =>
                {
                    TextBox textBox = obj as TextBox;
                    if (textBox != null)
                    {
                        textBox.FontSize *= 1.2;

                        if (SelectedItem is Category)
                        {
                            Category category = (Category)SelectedItem;
                            oldString = category.NameCategory;
                        }
                        else if (SelectedItem is TypesProduct)
                        {
                            TypesProduct typesProduct = (TypesProduct)SelectedItem;
                            oldString = typesProduct.NameTypeProduct;
                        }
                        else if (SelectedItem is Customer)
                        {
                            Customer customer = (Customer)SelectedItem;
                            if (textBox.Name == "Name")
                            {
                                oldString = customer.NameCustomer;
                            }
                            if (textBox.Name == "Family")
                            {
                                oldString = customer.FamilyCustomer;
                            }
                            if (textBox.Name == "Email")
                            {
                                oldString = customer.EmailCustomer;
                            }
                            if (textBox.Name == "Password")
                            {
                                oldString = customer.PasswordCustomer;
                            }
                        }
                        else if (SelectedItem is Employee)
                        {
                            Employee employee = (Employee)SelectedItem;
                            if (textBox.Name == "Name")
                            {
                                oldString = employee.NameEmployee;
                            }
                            else if (textBox.Name == "Family")
                            {
                                oldString = employee.FamilyEmployee;
                            }
                            else if (textBox.Name == "Email")
                            {
                                oldString = employee.EmailEmployee;
                            }
                            else if (textBox.Name == "Password")
                            {
                                oldString = employee.PasswordEmployee;
                            }
                            else if (textBox.Name == "Salary")
                            {
                                oldInt = (int)employee.SalaryEmployee;
                            }
                        }
                        else if (SelectedItem is OrderStatus)
                        {
                            OrderStatus orderStatus = (OrderStatus)SelectedItem;
                            oldString = orderStatus.Status;
                        }
                        else if (SelectedItem is OrderDetail)
                        {
                            OrderDetail orderDetail = (OrderDetail)SelectedItem;
                            oldInt = (int)orderDetail.CountProduct;
                        }
                        else if (SelectedItem is Provider)
                        {
                            Provider provider = (Provider)SelectedItem;
                            oldString = provider.NameProvider;
                        }
                        else if (SelectedItem is Product)
                        {
                            Product product = (Product)SelectedItem;
                            if (textBox.Name == "Name")
                            {
                                oldString = product.NameProduct;
                            }
                            else if (textBox.Name == "Quantity")
                            {
                                oldInt = (int)product.QuantityProduct;
                            }
                            else if (textBox.Name == "Rating")
                            {
                                oldDouble = (double)product.RatingProduct;
                            }
                            else if (textBox.Name == "Price")
                            {
                                oldInt = (int)product.PriceProduct;
                            }
                        }
                        else if (SelectedItem is Store)
                        {
                            Store store = (Store)SelectedItem;
                            if (textBox.Name == "City")
                            {
                                oldString = store.CityStore;
                            }
                            else if (textBox.Name == "Street")
                            {
                                oldString = store.StreetStore;
                            }
                            else if (textBox.Name == "House")
                            {
                                oldString = store.HouseStore;
                            }
                            else if (textBox.Name == "House_Number")
                            {
                                oldString = store.NumberStore;
                            }
                            else if (textBox.Name == "Rating")
                            {
                                oldDouble = (double)store.RatingStore;
                            }
                        }
                    }

                }));
            }
        }

        private RelayCommand lostFocusCommand;
        public RelayCommand LostFocusCommand
        {
            get
            {
                return lostFocusCommand ?? (lostFocusCommand = new RelayCommand(obj =>
                {
                    TextBox textBox = obj as TextBox;
                    if (textBox != null)
                    {
                        textBox.FontSize /= 1.2;

                        if (SelectedItem is Category)
                        {
                            Category category = (Category)SelectedItem;
                            //Test(textBox.Text);
                            Change(textBox.Text);
                        }
                        else if (SelectedItem is TypesProduct)
                        {
                            TypesProduct typesProduct = (TypesProduct)SelectedItem;
                            //Test(textBox.Text);
                            Change(textBox.Text);
                        }
                        else if (SelectedItem is Customer)
                        {
                            Customer customer = (Customer)SelectedItem;
                            if (textBox.Name == "Name")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Family")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Email")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Password")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                        }
                        else if (SelectedItem is Employee)
                        {
                            Employee employee = (Employee)SelectedItem;
                            if (textBox.Name == "Name")
                            {
                                //(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Family")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Email")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Password")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Salary")
                            {
                                //Test(Convert.ToInt32(textBox.Text));
                                Change(Convert.ToInt32(textBox.Text));
                            }
                        }
                        else if (SelectedItem is OrderStatus)
                        {
                            OrderStatus orderStatus = (OrderStatus)SelectedItem;
                            //Test(textBox.Text);
                            Change(textBox.Text);
                        }
                        else if (SelectedItem is OrderDetail)
                        {
                            OrderDetail orderDetail = (OrderDetail)SelectedItem;
                            //Test(Convert.ToInt32(textBox.Text));
                            Change(Convert.ToInt32(textBox.Text));
                        }
                        else if (SelectedItem is Provider)
                        {
                            Provider provider = (Provider)SelectedItem;
                            //Test(textBox.Text);
                            Change(textBox.Text);
                        }
                        else if (SelectedItem is Product)
                        {
                            Product product = (Product)SelectedItem;
                            if (textBox.Name == "Name")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Quantity")
                            {
                                //Test(Convert.ToInt32(textBox.Text));
                                Change(Convert.ToInt32(textBox.Text));
                            }
                            else if (textBox.Name == "Rating")
                            {
                                //Test(Convert.ToDouble(textBox.Text));
                                Change(Convert.ToDouble(textBox.Text));
                            }
                            else if (textBox.Name == "Price")
                            {
                                //Test(Convert.ToInt32(textBox.Text));
                                Change(Convert.ToInt32(textBox.Text));
                            }
                        }
                        else if (SelectedItem is Store)
                        {
                            Store store = (Store)SelectedItem;
                            if (textBox.Name == "City")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Street")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "House")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "House_Number")
                            {
                                //Test(textBox.Text);
                                Change(textBox.Text);
                            }
                            else if (textBox.Name == "Rating")
                            {
                                //Test(Convert.ToDouble(textBox.Text));
                                Change(Convert.ToDouble(textBox.Text));
                            }
                        }
                    }

                }));
            }
        }

        private RelayCommand selectionChangedCommand;
        public RelayCommand SelectionChangedCommand
        {
            get
            {
                return selectionChangedCommand ?? (selectionChangedCommand = new RelayCommand(obj =>
                {
                    ComboBox comboBox = obj as ComboBox;
                    if (comboBox != null)
                    {
                        //if (SelectedItem is TypesProduct)
                        //{
                            //TypesProduct typesProduct = (TypesProduct)SelectedItem;
                            //Category category = (Category)comboBox.SelectedItem;
                            //string newString = category.NameCategory;
                            //oldString = typesProduct.IdCategoryNavigation.NameCategory;

                            Change();
                            
                            //Test(newString);
                        //}
                    }
                        
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
