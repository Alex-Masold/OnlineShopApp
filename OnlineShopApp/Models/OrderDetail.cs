using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class OrderDetail
{
    public int IdDetail { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int CountProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
