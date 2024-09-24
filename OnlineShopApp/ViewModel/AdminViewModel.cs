using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShopApp.DataSource;
using OnlineShopApp.Models;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace OnlineShop.ViewModel
{
    public class AdminViewModel : PropertyChange
    {
        private ApplicationContext db = new ApplicationContext();

        private string oldString;
        private int oldInt;
        private double oldDouble;
        private DispatcherTimer timer;

        #region Категории
        public ObservableCollection<Category> Categories { get; set; }
        #endregion

        #region Типы Продуктов
        public ObservableCollection<TypesProduct> TypesProducts { get; set; }
        #endregion

        #region Сотрудники
        public ObservableCollection<Employee> Employees { get; set; }
        #endregion

        #region Клиенты
        public ObservableCollection<Customer> Customers { get; set; }
        #endregion

        #region Статусы Заказа
        public ObservableCollection<OrderStatus> OrderStatuses { get; set; }
        #endregion

        #region Заказы
        public ObservableCollection<Order> Orders { get; set; }
        #endregion

        #region Детали Заказа
        public ObservableCollection<OrderDetail> OrderDetails { get; set; }
        #endregion

        #region Поставщики
        public ObservableCollection<Provider> Providers { get; set; }
        #endregion

        #region Продукты
        public ObservableCollection<Product> Products { get; set; }
        #endregion

        #region Магазины
        public ObservableCollection<Store> Stores { get; set; }
        #endregion

        Popup Notification { get; set; }

        private string message; 
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

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
                    Message = "Изменений Нет";
                    Open();
                }
                else
                {
                    Message = ($"{oldString} -> {newVersion}");
                    Open();
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
                    MessageBox.Show($"{oldInt} -> {newVersion}");
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
                    Message = "Изменений Нет";
                    Open();
                }
                else
                {
                    Message = ($"{oldDouble} -> {newVersion}");
                    Open();
                    db.Entry(SelectedItem).State = EntityState.Modified;
                    db.SaveChanges();
                }

            }
        }

        private void Open()
        {
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2); // Закроется через 5 секунд
            timer.Tick += Close;

            Notification.IsOpen = true;

            timer.Start();
        }
        private void Close(object sender, EventArgs e)
        {
            Notification.IsOpen = false;

            // Останавливаем таймер
            timer.Stop();
        }

        private void TextBoxGotFocus(string name)
        {
            switch (SelectedItem)
            {
                case Category category:
                    oldString = category.NameCategory;
                    break;
                case Customer customer:
                    switch (name)
                    {
                        case "Name":
                            oldString = customer.NameCustomer; 
                            break;
                        case "Family":
                            oldString = customer.FamilyCustomer;
                            break;
                        case "Email":
                            oldString = customer.EmailCustomer;
                            break;
                        case "Password":
                            oldString = customer.PasswordCustomer;
                            break;
                    }
                    break;
                case Employee employee:
                    switch (name)
                    {
                        case "Name":
                            oldString = employee.NameEmployee;
                            break;
                        case "Family":
                            oldString = employee.FamilyEmployee;
                            break;
                        case "Email":
                            oldString = employee.EmailEmployee;
                            break;
                        case "Password":
                            oldString = employee.PasswordEmployee;
                            break;
                        case "Salary":
                            oldInt = (int)employee.SalaryEmployee;
                            break;
                    }
                    break;
                case OrderStatus orderStatus:
                    oldString = orderStatus.NameStatus;
                    break;
                case OrderDetail orderDetail:
                    oldInt = (int)orderDetail.CountProduct;
                    break;
                case Provider provider:
                    oldString = provider.NameProvider;
                    break;
                case Product product:
                    switch (name)
                    {
                        case "Name":
                            oldString = product.NameProduct;
                            break;
                        case "Quantity":
                            oldInt = (int)product.QuantityProduct;
                            break;
                        case "Price":
                            oldInt = (int)product.PriceProduct;
                            break;
                    }
                    break;
                case Store store:
                   switch (name)
                    {
                        case "City":
                            oldString = store.CityStore;
                            break;
                        case "Street":
                            oldString = store.StreetStore;
                            break;
                        case "House":
                            oldString = store.HouseStore;
                            break;
                        case "House_Number":
                            oldString = store.NumberStore;
                            break;
                    }
                    break;
                case TypesProduct typesProduct:
                    oldString = typesProduct.NameTypeProduct;
                    break;
            }
        }
        private void ComboBoxGotFocus(string name)
        {
            switch (SelectedItem)
            {
                case Employee employee:
                    switch (employee.IdStoreNavigation)
                    {
                        case null:
                            oldString = "";
                            break;
                        default:
                            oldString = employee.IdStoreNavigation.Name;
                            break;
                    }
                    break;
                case Order order: 
                    switch (name)
                    {
                        case "StatusComboBox":
                            switch (order.IdOrderStatusNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default:
                                    oldString = order.IdOrderStatusNavigation.Name;
                                    break;
                            }
                            break;
                        case "CustomersComboBox":
                            switch (order.IdCustomerNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default:
                                    oldString = order.IdCustomerNavigation.Name;
                                    break;
                            }
                            break;
                        case "StoresComboBox":
                            switch (order.IdStoreNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default:
                                    oldString = order.IdStoreNavigation.Name;
                                    break;
                            }
                            break;
                        case "EmployeeComboBox":

                            switch (order.IdEmployeeNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default:
                                    oldString = order.IdEmployeeNavigation.Name;
                                    break;
                            }
                            break;
                    }
                    break;
                case OrderDetail orderDetail:
                    switch (name)
                    {
                        case "OrdersComboBox":
                            switch (orderDetail.IdOrderNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default:
                                    oldString = orderDetail.IdOrderNavigation.Name;
                                    break;
                            }
                            break;
                        case "ProductsComboBox":
                            switch (orderDetail.IdProductNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break; 
                                default:
                                    oldString = orderDetail.IdProductNavigation.Name;
                                    break;
                            }
                            break;
                    }
                    break;
                case Product product:
                    switch (name)
                    {
                        case "TypesProductsComboBox":
                            switch (product.IdTypeProductNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default :
                                    oldString = product.IdTypeProductNavigation.NameTypeProduct;
                                    break;
                            }
                            break;
                        case "ProvidersComboBox":
                            switch (product.IdProviderNavigation)
                            {
                                case null:
                                    oldString = "";
                                    break;
                                default:
                                    oldString = product.IdProviderNavigation.NameProvider;
                                    break;
                            }
                            break;
                    }
                    break;
                case TypesProduct typesProduct:
                    switch (typesProduct.IdCategoryNavigation)
                    {
                        case null:
                            oldString = "";
                            break;
                        default:
                            oldString = typesProduct.IdCategoryNavigation.NameCategory;
                            break;

                    }
                    break;
            }
        }

        private void SelectionChanged(string name)
        {
            switch (SelectedItem)
            {
                case Employee employee:
                    switch (employee.IdStoreNavigation)
                    {
                        case null:
                            Message = "Магазин не был выбран";
                            Open();
                            break;
                        default:
                            Change(employee.IdStoreNavigation.Name);
                            break;
                    }
                    break;
                case Order order:
                    switch (name)
                    {
                        case "StatusComboBox":
                            switch (order.IdOrderStatusNavigation)
                            {
                                case null:
                                    Message = "Статус не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(order.IdOrderStatusNavigation.NameStatus);
                                    break;
                            }
                            break;
                        case "CustomersComboBox":
                            switch (order.IdCustomerNavigation)
                            {
                                case null:
                                    Message = "Клиент не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(order.IdCustomerNavigation.Name);
                                    break;
                            }
                            break;
                        case "StoresComboBox":
                            switch (order.IdStoreNavigation)
                            {
                                case null:
                                    Message = "Магазин не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(order.IdStoreNavigation.Name);
                                    break;
                            }
                            break;
                        case "EmployeeComboBox":
                            switch (order.IdEmployeeNavigation)
                            {
                                case null:
                                    Message = "Сотрудник не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(order.IdEmployeeNavigation.Name);
                                    break;
                            }
                            break;
                    }
                    break;
                case OrderDetail orderDetail:
                    switch (name)
                    {
                        case "OrdersComboBox":
                            switch (orderDetail.IdOrderNavigation)
                            {
                                case null:
                                    Message = "Заказ не был выбран";
                                    Open();
                                    break; 
                                default:
                                    Change(orderDetail.IdOrderNavigation.Name);
                                    break;
                            }
                            break;
                        case "ProductsComboBox":
                            switch (orderDetail.IdProductNavigation)
                            {
                                case null:
                                    Message = "Продукт не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(orderDetail.IdProductNavigation.Name);
                                    break;
                            }
                            break;
                    }
                    break;
                case Product product:
                    switch (name)
                    {
                        case "TypesProductsComboBox":
                            switch (product.IdTypeProductNavigation)
                            {
                                case null:
                                    Message = "Тип продукта не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(product.IdTypeProductNavigation.NameTypeProduct);
                                    break;
                            }
                            break;
                        case "ProvidersComboBox":
                            switch (product.IdProviderNavigation)
                            {
                                case null:
                                    Message = "Продукт не был выбран";
                                    Open();
                                    break;
                                default:
                                    Change(product.IdProviderNavigation.NameProvider);
                                    break;
                            }
                            break;
                    }
                    break;
                case TypesProduct typesProduct:
                    switch (typesProduct.IdCategoryNavigation)
                    {
                        case null:
                            Message = "Категория не был выбран";
                            Open();
                            break;
                        default:
                            Change(typesProduct.IdCategoryNavigation.NameCategory);
                            break;
                    }
                    break;
            }
        }
        private void Add(string name)
        {
            switch (name)
            {
                case "Categories":
                    Category newCategory = new Category();
                    db.Categories.Add(newCategory);
                    db.SaveChanges();
                    break;
                case "Customers":
                    db.Customers.Add(new Customer());
                    db.SaveChanges();
                    break;
                case "Employees":
                    db.Employees.Add(new Employee());
                    db.SaveChanges();
                    break;
                case "OrderDetails":
                    db.OrderDetails.Add(new OrderDetail());
                    db.SaveChanges();
                    break;
                case "Orders":
                    db.Orders.Add(new Order());
                    db.SaveChanges();
                    break;
                case "OrdersStatuses":
                    db.OrderStatuses.Add(new OrderStatus());
                    db.SaveChanges();
                    break;
                case "Products":
                    db.Products.Add(new Product());
                    db.SaveChanges();
                    break;
                case "Providers":
                    db.Providers.Add(new Provider());
                    db.SaveChanges();
                    break;
                case "Stores":
                    db.Stores.Add(new Store());
                    db.SaveChanges();
                    break;
                case "TypesProducts":
                    db.TypesProducts.Add(new TypesProduct());
                    db.SaveChanges();
                    break;
            }   
        }
        private void Delete()
        {
            switch (SelectedItem)
            {
                case Category _:
                    db.Categories.Remove((Category)SelectedItem);
                    db.SaveChanges();
                    break;
                case TypesProduct _:
                    db.TypesProducts.Remove((TypesProduct)SelectedItem);
                    db.SaveChanges();
                    break;
                case Customer _:
                    db.Customers.Remove((Customer)SelectedItem);
                    db.SaveChanges();
                    break;
                case Employee _:
                    db.Employees.Remove((Employee)SelectedItem);
                    db.SaveChanges();
                    break;
                case OrderStatus _:
                    db.OrderStatuses.Remove((OrderStatus)SelectedItem);
                    db.SaveChanges();
                    break;
                case Order _:
                    db.Orders.Remove((Order)SelectedItem);
                    db.SaveChanges();
                    break;
                case OrderDetail _:
                    db.OrderDetails.Remove((OrderDetail)SelectedItem);
                    db.SaveChanges();
                    break;
                case Provider _:
                    db.Providers.Remove((Provider)SelectedItem);
                    db.SaveChanges();
                    break;
                case Product _:
                    db.Products.Remove((Product)SelectedItem);
                    db.SaveChanges();
                    break;
                case Store _:
                    db.Stores.Remove((Store)SelectedItem);
                    db.SaveChanges();
                    break;
                default:
                    MessageBox.Show("Объект не выбран");
                    break;
            }
        }

        private RelayCommand gotFocusCommand;
        public RelayCommand GotFocusCommand
        {
            get
            {
                return gotFocusCommand ?? (gotFocusCommand = new RelayCommand(obj =>
                {
                    switch (obj)
                    {
                        case TextBox textBox:
                            textBox.FontSize *= 1.2;
                            TextBoxGotFocus(textBox.Name);
                            break;
                    }
                }));
            }
        }

        private RelayCommand dropDownCommand;
        public RelayCommand DropDownCommand
        {
            get
            {
                return dropDownCommand ?? (dropDownCommand = new RelayCommand(obj => 
                {
                    switch (obj)
                    {
                        case ComboBox comboBox:
                            ComboBoxGotFocus(comboBox.Name);
                            break;
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
                        SelectionChanged(comboBox.Name);
                    }
                 }));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    ListView listView = obj as ListView;
                    if (listView != null)
                    {
                        Add(listView.Name);
                    }
                }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (new RelayCommand(obj =>
                {
                    Delete();
                }));
            }
        }

        public AdminViewModel(Popup notification)
        {
            Categories =    StaticData.GetAllCategories(db);

            TypesProducts = StaticData.GetAllTypesProducts(db);

            Customers =     StaticData.GetAllCustomers(db);

            Employees =     StaticData.GetAllEmployees(db);

            Orders =        StaticData.GetAllOrders(db);

            OrderStatuses = StaticData.GetAllOrderStatuses(db);

            OrderDetails =  StaticData.GetAllOrderDetails(db);

            Products =      StaticData.GetAllProducts(db);

            Providers =     StaticData.GetAllProviders(db);

            Stores =        StaticData.GetAllStores(db);

            Notification=notification;
        }
    } 
}
