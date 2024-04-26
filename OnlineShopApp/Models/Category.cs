using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? NameCategory { get; set; }

    public virtual ICollection<TypesProduct> TypesProducts { get; set; } = new List<TypesProduct>();
}
