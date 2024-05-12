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
            OnPropertyChanged(nameof(Name));
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
            OnPropertyChanged(nameof(Name));
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
    public string Name { 
        get { return $"{familyCustomer} {familyCustomer}"; } 
        set 
        {
            string[] components = value.Split(' ');
            if (components.Length == 2 )
            {
                familyCustomer = components[0];
                familyCustomer = components[1];
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
