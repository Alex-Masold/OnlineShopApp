using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Store : PropertyChange
{
    public int IdStore { get; set; }

    public string? CityStore { get; set; } = null!;

    public string? StreetStore { get; set; } = null!;

    public string? HouseStore { get; set; } = null!;

    public string? NumberStore { get; set; } = null!;

    public double? RatingStore { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public string Name { get { return CityStore + ' ' + StreetStore +' ' + HouseStore; } }
}
