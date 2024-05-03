using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Provider : PropertyChange
{
    public int IdProvider { get; set; }

    private string? nameProvider;
    public string? NameProvider 
    { 
        get { return nameProvider; }
        set
        {
            nameProvider = value;
            OnPropertyChanged(nameof(NameProvider));
        }
    }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
