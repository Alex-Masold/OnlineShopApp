using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class TypesProduct : PropertyChange
{
    public int IdTypeProduct { get; set; }

    private string? nameTypesProduct;
    public string? NameTypeProduct 
    { 
        get {  return nameTypesProduct; }
        set
        {
            nameTypesProduct = value;
            OnPropertyChanged(nameof(NameTypeProduct));
        }
    }

    private int? idCategory;
    public int? IdCategory 
    { 
        get { return idCategory; }
        set
        {
            idCategory = value;
            OnPropertyChanged(nameof(IdCategory));
        }
    }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [NotMapped]
    public ObservableCollection<Product> ObservableProducts
    {
        get { return new ObservableCollection<Product>(Products); }
    }
}
