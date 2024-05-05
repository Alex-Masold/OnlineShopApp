using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Customer : PropertyChange
{
    public int IdCustomer { get; set; }

    private string? nameCustomer;
    public string? NameCustomer 
    { 
        get { return nameCustomer; }
        set
        {
            nameCustomer = value;
            OnPropertyChanged(nameof(NameCustomer));
        }
    }

    private string? familyCustomer;
    public string? FamilyCustomer 
    { 
        get { return familyCustomer; }
        set
        {
            familyCustomer = value;
            OnPropertyChanged(nameof(FamilyCustomer));
        }
    }

    private string? emailCustomer;
    public string? EmailCustomer 
    { 
        get { return emailCustomer; }
        set
        {
            emailCustomer = value;
            OnPropertyChanged(nameof(EmailCustomer));
        }
    }

    private string? passwordCustomer;
    public string? PasswordCustomer 
    { 
        get { return  passwordCustomer; }
        set
        {
            passwordCustomer = value;
            OnPropertyChanged(nameof(PasswordCustomer));
        }
    }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [NotMapped]
    public ObservableCollection<Order> ObservableOrders { get { return new ObservableCollection<Order>(Orders); } }

    public string Name { get { return NameCustomer + ' ' + FamilyCustomer; } }

    [NotMapped]
    private bool isEditName;
    [NotMapped]
    public bool IsEditName
    {
        get { return isEditName; }
        set
        {
            isEditName = value;
            OnPropertyChanged(nameof(IsEditName));
        }
    }

    [NotMapped]
    private bool isEditFamily;
    [NotMapped]
    public bool IsEditFamily
    {
        get { return isEditFamily; }
        set
        {
            isEditFamily = value;
            OnPropertyChanged(nameof(IsEditFamily));
        }
    }

    [NotMapped]
    private bool isEditEmail;
    [NotMapped]
    public bool IsEditEmail
    {
        get { return isEditEmail; }
        set
        {
            isEditEmail = value;
            OnPropertyChanged(nameof(IsEditEmail));
        }
    }

    [NotMapped]
    private bool isEditPassword;
    [NotMapped]
    public bool IsEditPassword
    {
        get { return isEditPassword; }
        set
        {
            isEditPassword = value;
            OnPropertyChanged(nameof(IsEditPassword));
        }
    }
}
