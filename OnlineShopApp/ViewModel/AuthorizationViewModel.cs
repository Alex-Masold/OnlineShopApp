using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShop.Views.Pages;
using OnlineShopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShop.ViewModel
{
    public class AuthorizationViewModel : PropertyChange
    {
        private string email;
        public string Email 
        { 
            get {return email; } 
            set {
                email = value;
                OnPropertyChanged(nameof(Email));
            } 
        }

        private string password;
        public string Password
        {
            get {return password; } 
            set 
            { 
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private Employee currentEmployee;
        private Customer currentCustomers;

        private void Check()
        {
            if (email.Contains("@store"))
            {
                currentEmployee = StaticData.GetEmployee(Email, Password);
            }
            else
            {
                currentCustomers = StaticData.GetCustomer(Email, Password);
            }
        }

        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ?? (logInCommand = new RelayCommand(obj =>
                {
                    Check();

                    if (currentCustomers != null)
                    {
                        StaticData.MainContentFrame.Navigate(new CustomerView(currentCustomers));
                        StaticData.MainContentFrame.NavigationUIVisibility.Equals(Visibility.Hidden);
                    }
                    else if (currentEmployee != null)
                    {
                        StaticData.MainContentFrame.Navigate(new EmployeeView(currentEmployee));
                        StaticData.MainContentFrame.NavigationUIVisibility.Equals(Visibility.Hidden);
                    }
                    else
                    {
                        StaticData.MainContentFrame.Navigate(new AdminView());
                        StaticData.MainContentFrame.NavigationUIVisibility.Equals(Visibility.Hidden);
                    }
                }));
            }
        }

        public AuthorizationViewModel()
        {
            //Email = "ivan.petrov@gmail.com";
            //Password = "p@ssw0rd1!"; 
            Email = "ivan.petrov@store1.com";
            Password = "!2dK@";
        }
    }
}
