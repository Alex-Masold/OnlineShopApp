using System;
using System.Collections.Generic;

namespace OnlineShopApp.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public DateOnly DateOrder { get; set; }

    public int? IdEmployee { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; } = null!;

    public virtual Employee? IdEmployeeNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
