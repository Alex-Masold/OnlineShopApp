using OnlineShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Security.RightsManagement;

namespace OnlineShopApp.Views.Controls.Templates
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate Category { get; set; }
        public DataTemplate TypeProduct { get; set; }
        public DataTemplate Customer { get; set; }
        public DataTemplate Employee { get; set; }
        public DataTemplate OrderStatus { get; set; }
        public DataTemplate Order {  get; set; }
        public DataTemplate OrderDetail { get; set; }
        public DataTemplate Provider {  get; set; }
        public DataTemplate Product { get; set; }
        public DataTemplate Store { get; set; }
        public DataTemplate Hidden { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Category)
            {
                return Category;
            }
            else if (item is TypesProduct)
            {
                return TypeProduct;
            }
            else if (item is Customer)
            {
                return Customer;
            }
            else if (item is Employee)
            {
                return Employee;
            }
            else if (item is OrderStatus)
            {
                return OrderStatus;
            }
            else if (item is Order)
            {
                return Order;
            }
            else if (item is OrderDetail)
            {
                return OrderDetail;
            }
            else if (item is Provider)
            {
                return Provider;
            }
            else if (item is Product)
            {
                return Product;
            }
            else if (item is Store)
            {
                return Store;
            }
            else
            {
                return Hidden;
            }
        }
    }
}
