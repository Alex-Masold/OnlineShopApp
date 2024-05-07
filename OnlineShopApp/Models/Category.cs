using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Category : PropertyChange
{
    public int IdCategory { get; set; }

    private string? nameCategory;
    public string? NameCategory 
    { 
        get {  return nameCategory; }
        set
        {
            nameCategory = value;
            OnPropertyChanged(nameof(NameCategory));
        }
    }

    public virtual ICollection<TypesProduct> TypesProducts { get; set; } = new List<TypesProduct>();
}
