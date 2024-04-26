using OnlineShop.Models;
using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShop.Views.Pages;
using OnlineShopApp.Models;
using System;
using System.Collections.Generic;
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

        private List<Customer> customers = StaticData.GetAllCustomers();
        private List<Employee> employees = StaticData.GetAllEmployees();

        private Employee currentEmployee;
        private Customer currentCustomers;

        private void Check(string email, string password)
        {
            if (email.Contains("@store"))
            {
                foreach (var employee in employees)
                {
                    if ( (email == employee.EmailEmployee) && (password == employee.PasswordEmployee))
                    {
                        currentEmployee = employee;
                    }
                    else
                    {
                        if (email != employee.EmailEmployee) 
                        { 
                            Email = "Не верный Email";
                        }
                        if (password != employee.PasswordEmployee)
                        {
                            Password = "Не верный пароль";
                        }
                    }
                }
            }
            else
            {
                foreach(var customer in customers)
                {
                    if ((email == customer.EmailCustomer) && (password == customer.PasswordCustomer))
                    {
                        currentCustomers = customer;
                    }
                    else
                    {
                        if (email != customer.EmailCustomer)
                        {
                            Email = "Не верный Email";
                        }
                        if (password != customer.PasswordCustomer)
                        {
                            Password = "Не верный пароль";
                        }
                    }
                }
            }
        }

        private RelayCommand logInCommand;
        public RelayCommand LogInCommand
        {
            get
            {
                return logInCommand ?? (logInCommand = new RelayCommand(obj =>
                {
                    Check(Email, Password);

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
            Email = "ivan.petrov@gmail.com";
            Password = "p@ssw0rd1!";
        }
    }
}
