using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class TypesProduct
{
    public int IdTypeProduct { get; set; }

    public string NameTypeProduct { get; set; } = null!;

    public int IdCategory { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
