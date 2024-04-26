﻿using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShop.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationView.xaml
    /// </summary>
    public partial class AuthorizationView : Page
    {
        public AuthorizationView()
        {
            InitializeComponent();
            DataContext = new AuthorizationViewModel();

        }
    }
}
