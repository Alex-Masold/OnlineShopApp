﻿using OnlineShop.ViewModel;
using OnlineShopApp.Models;
using System.Windows.Controls;
using System.Windows.Forms;


namespace OnlineShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Page
    { 
        public CustomerView(Customer customer)
        {
            InitializeComponent();
            DataContext = new CustomerViewModel(customer);
        }
    }
}
