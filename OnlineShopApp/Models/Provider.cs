using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Provider
{
    public int IdProvider { get; set; }

    public string NameProvider { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
