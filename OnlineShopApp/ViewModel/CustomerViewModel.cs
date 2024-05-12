using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShop.Views.Pages;
using OnlineShopApp.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.ObjectModel;
using Microsoft.Identity.Client;
using OnlineShopApp.DataSource;
using System.Reflection.Emit;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.ViewModel
{
    public class CustomerViewModel : PropertyChange
    {
        private ApplicationContext db;
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products { 
            get { return products; } 
            set 
            { 
                products = value; 
                OnPropertyChanged(nameof(Products));
            }
        }   

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

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private OrderDetail selectedOrderDetail;
        public OrderDetail SelectedOrderDetail
        {
            get { return selectedOrderDetail; }
            set
            {
                selectedOrderDetail = value;
                OnPropertyChanged(nameof(SelectedOrderDetail));
            }
        }

        private Order newOrder;
        public Order NewOrder
        { 
            get { return newOrder; }
            set 
            { 
                newOrder = value; 
                OnPropertyChanged(nameof(NewOrder)); 
            }
        }
        public void AddOrder()
        {
            if (NewOrder == null)
            {
                NewOrder = new Order()
                {   
                    IdCustomer = Customer.IdCustomer,
                    IdOrderStatus = 1,
                    DateOrder = DateOnly.FromDateTime(DateTime.Now.Date)
                };

                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }
                Customer = StaticData.GetCustomer(Customer.IdCustomer);
            }
        }

        async public void AddOrderDetail(Product _product)
        {
            OrderDetail detail;
            bool checkIsExist;
            using (ApplicationContext db = new ApplicationContext())
            {
                checkIsExist = StaticData.GetOrder(NewOrder.IdOrder).OrderDetails.Any(_detail => _detail.IdProduct == _product.IdProduct);

                if (!checkIsExist && _product.QuantityProduct >= 0)
                {
                    detail = new OrderDetail
                    {
                        IdOrder = NewOrder.IdOrder,
                        IdProduct = _product.IdProduct,
                        CountProduct = 1
                    };
                    await db.Products.Where(p => p.IdProduct == _product.IdProduct).ExecuteUpdateAsync(p => p.SetProperty(p => p.QuantityProduct, p => p.QuantityProduct -1));

                    await db.OrderDetails.AddAsync(detail);
                    await db.SaveChangesAsync();

                }
                else
                {
                    detail = StaticData.GetOrder(NewOrder.IdOrder).OrderDetails.FirstOrDefault(_detail => _detail.IdProduct == _product.IdProduct);
                 
                    await db.OrderDetails.Where(d => d.IdDetail == detail.IdDetail)
                            .ExecuteUpdateAsync(d =>
                                d.SetProperty(d =>
                                    d.CountProduct,
                                    d => d.CountProduct +1));
                    //await db.Products.Where(p => p.IdProduct == _product.IdProduct)
                    //        .ExecuteUpdateAsync(p =>
                    //            p.SetProperty(p =>
                    //                p.QuantityProduct,
                    //                p => p.QuantityProduct -1));
                }

            }


            //Products = new ObservableCollection<Product>(StaticData.GetAllProducts(db));
            //NewOrder = StaticData.GetOrder(NewOrder.IdOrder);
        }
        async public void DownCount(int id)
        {
            OrderDetail detail;
            Product product;
            using (ApplicationContext db = new ApplicationContext())
            {
                detail = StaticData.GetOrder(NewOrder.IdOrder).OrderDetails.FirstOrDefault(_detail => _detail.IdDetail == id);


                product = StaticData.GetProduct((int)detail.IdProduct);

                if (detail.CountProduct > 0)
                {
                    await db.OrderDetails.Where(d => d.IdDetail == detail.IdDetail)
                        .ExecuteUpdateAsync(d =>
                            d.SetProperty(d =>
                                d.CountProduct,
                                d => d.CountProduct -1));
                    await db.Products.Where(p => p.IdProduct == product.IdProduct).ExecuteUpdateAsync(p => p.SetProperty(p => p.QuantityProduct, p => p.QuantityProduct +1));

                    

                }
                detail = StaticData.GetOrder(NewOrder.IdOrder).OrderDetails.FirstOrDefault(_detail => _detail.IdDetail == id);
                if (detail.CountProduct == 0)
                {
                    db.OrderDetails.Remove(detail);
                    await db.SaveChangesAsync();
                }
                //Products = new ObservableCollection<Product>(StaticData.GetAllProducts());
                //NewOrder = StaticData.GetOrder(NewOrder.IdOrder);
            }
        }
        async public void EndOrder()
        {
            if (NewOrder != null)
            {
                bool checkIsExist;
                Order order;
                using (ApplicationContext db = new ApplicationContext())
                {
                    checkIsExist = db.Orders.Any(_order => _order.IdCustomer == Customer.IdCustomer && _order.IdOrderStatus == 2);
                    if (checkIsExist)
                    {
                        order = db.Orders.FirstOrDefault(_order => _order.IdCustomer == Customer.IdCustomer && _order.IdOrderStatus == 1);
                        order.IdOrderStatus = 2;
                        db.Orders.Update(order);
                        await db.SaveChangesAsync();

                        NewOrder = null;
                    }
                }
                Customer = StaticData.GetCustomer(Customer.IdCustomer);
            }
        }

        private RelayCommand addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                return addOrderCommand ?? (addOrderCommand = new RelayCommand(obj =>
                {
                    Product product = obj as Product;
                    if (product != null)
                    {
                        AddOrder();
                        AddOrderDetail(product);
                    }

                }));
            }
        }

        private RelayCommand downCountCommand;
        public RelayCommand DownCountCommand
        {
            get
            {
                return downCountCommand ?? (downCountCommand = new RelayCommand(obj =>
                {
                    OrderDetail detail = obj as OrderDetail;
                    if (detail != null)
                    {
                        DownCount(detail.IdDetail);
                    }
                }));
            }
        }

        private RelayCommand endOrderCommand;
        public RelayCommand EndOrderCommand
        {
            get
            {
                return endOrderCommand ?? (endOrderCommand = new RelayCommand(obj =>
                {
                    EndOrder();
                }));
            }
        }

        public CustomerViewModel(Customer _customer)
        {
            Customer = _customer;
            Products = StaticData.GetAllProducts(db);
            NewOrder = Customer.Orders.FirstOrDefault(_order => _order.IdOrderStatusNavigation.Status == "В корзине") ?? null;
        }
    }
}
