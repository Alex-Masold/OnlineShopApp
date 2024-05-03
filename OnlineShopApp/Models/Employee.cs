using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Employee : PropertyChange
{
    public int IdEmployee { get; set; }

    public string NameEmployee { get; set; } = null!;

    public string? FamilyEmployee { get; set; } = null!;

    public string EmailEmployee { get; set; } = null!;

    public string? PasswordEmployee { get; set; }

    public int? IdStore { get; set; }

    public int? SalaryEmployee { get; set; }

    public virtual Store? IdStoreNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set;} = new List<Order>();

    public string Name { get { return FamilyEmployee + ' ' + NameEmployee; } }


}
