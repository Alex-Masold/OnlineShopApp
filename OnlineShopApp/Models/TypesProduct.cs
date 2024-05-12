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

    private Category idCategoryNavigation;
    public virtual Category IdCategoryNavigation 
    {
        get { return idCategoryNavigation; }
        set
        {
            idCategoryNavigation = value;
            OnPropertyChanged(nameof(IdCategoryNavigation));
        }
    }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
