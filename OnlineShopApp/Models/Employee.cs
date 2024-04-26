using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string NameEmployee { get; set; } = null!;

    public string FamilyEmployee { get; set; } = null!;

    public string EmailEmployee { get; set; } = null!;

    public int IdStore { get; set; }

    public int? SalaryEmployee { get; set; }

    public bool? IsDelete { get; set; }

    public string? PasswordEmployee { get; set; }

    public virtual Store IdStoreNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
