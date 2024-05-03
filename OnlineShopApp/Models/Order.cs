using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Order : PropertyChange
{
    public int IdOrder { get; set; }

    private DateOnly? dateOrder;
    public DateOnly? DateOrder 
    { 
        get { return dateOrder; }
        set
        {
            dateOrder = value;
            OnPropertyChanged(nameof(DateOrder));
        }
    }

    private int? idCustomer;
    public int? IdCustomer 
    {
        get { return idCustomer; }
        set
        {
            idCustomer = value;
            OnPropertyChanged(nameof(IdCustomer));
        }
    }

    private int? idOrderStatus;
    public int? IdOrderStatus 
    { 
        get {  return idOrderStatus; }
        set
        {
            idOrderStatus = value;
            OnPropertyChanged(nameof(IdOrderStatus));
        }
    }

    private int? idStore;
    public int? IdStore 
    { 
        get { return idStore; }
        set
        {
            IdStore = value;
            OnPropertyChanged(nameof(IdStore));
        }
    }

    private int? idEmployee;
    public int? IdEmployee 
    {
        get { return idEmployee; }
        set
        {
            idEmployee = value;
            OnPropertyChanged(nameof(IdEmployee));
        }
    }

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
