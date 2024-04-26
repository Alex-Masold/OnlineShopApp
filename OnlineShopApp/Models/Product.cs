using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public int QuantityProduct { get; set; }

    public int IdProvider { get; set; }

    public double? RatingProduct { get; set; }

    public int IdTypeProduct { get; set; }

    public int? PriceProduct { get; set; }

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual TypesProduct IdTypeProductNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
