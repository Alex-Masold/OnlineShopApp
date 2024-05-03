using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Order : PropertyChange
{
    public int IdOrder { get; set; }
    public int? IdCustomer { get; set; }
    public DateOnly? DateOrder { get; set; }
    public int? IdOrderStatus { get; set; }
    public int? IdStore { get; set; }
    public int? IdEmployee { get; set; }

    public virtual Customer? IdCustomerNavigation { get; set; } = null!;
    public virtual OrderStatus? IdOrderStatusNavigation { get; set; } = null!;
    public virtual Store? IdStoreNavigation { get; set; } = null!;
    public virtual Employee? IdEmployeeNavigation { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [NotMapped]
    public ObservableCollection<OrderDetail> ObservableOrderDetails{ get { return new ObservableCollection<OrderDetail>(OrderDetails); } }

    public int TotalCost { 
        get 
        {
            int totalCost = 0;
            foreach (OrderDetail detail in OrderDetails)
            {
                totalCost += detail.Price;
            }
            return totalCost;
        } 
    } 

    public string Name { get { return IdOrder + " " + DateOrder.ToString(); } }
}
