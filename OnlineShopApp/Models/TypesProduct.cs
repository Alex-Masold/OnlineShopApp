using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class TypesProduct : PropertyChange
{
    public int IdTypeProduct { get; set; }

    public string? NameTypeProduct { get; set; } = null!;

    public int? IdCategory { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [NotMapped]
    public ObservableCollection<Product> ObservableProducts
    {
        get { return new ObservableCollection<Product>(Products); }
    }
}
