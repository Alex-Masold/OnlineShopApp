using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Store
{
    public int IdStore { get; set; }

    public string CityStore { get; set; } = null!;

    public string StreetStore { get; set; } = null!;

    public string HouseStore { get; set; } = null!;

    public string NumberStore { get; set; } = null!;

    public double? RatingStore { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
