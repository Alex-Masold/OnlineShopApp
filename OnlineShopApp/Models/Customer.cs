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

    public string? NameCustomer { get; set; }

    public string? FamilyCustomer { get; set; }

    public string? EmailCustomer { get; set; }

    public string? PasswordCustomer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [NotMapped]
    public ObservableCollection<Order> ObservableOrders { get { return new ObservableCollection<Order>(Orders); } }

    public string Name { get { return NameCustomer + ' ' + FamilyCustomer; } }
}
