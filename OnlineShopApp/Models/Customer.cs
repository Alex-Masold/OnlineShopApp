using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string? NameCustomer { get; set; }

    public string? FamilyCustomer { get; set; }

    public string? EmailCustomer { get; set; }

    public string? PasswordCustomer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
