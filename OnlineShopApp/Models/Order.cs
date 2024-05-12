using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

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
            idStore = value;
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

    private Customer idCustomerNavigation;
    public virtual Customer? IdCustomerNavigation 
    { 
        get {  return  idCustomerNavigation; }
        set
        {
            idCustomerNavigation = value;
            OnPropertyChanged(nameof(IdCustomerNavigation));
        }
    }

    private OrderStatus idOrderStatusNavigation;
    public virtual OrderStatus? IdOrderStatusNavigation 
    { 
        get { return  idOrderStatusNavigation; }
        set
        {
            idOrderStatusNavigation = value;
            OnPropertyChanged(nameof(IdOrderStatusNavigation));
        }
    }

    private Store idStoreNavigation;
    public virtual Store? IdStoreNavigation 
    { 
        get { return idStoreNavigation; }
        set
        {
            idStoreNavigation = value;
            OnPropertyChanged(nameof(IdStoreNavigation)); 
        }
    }

    private Employee idEmployeeNavigation;
    public virtual Employee? IdEmployeeNavigation 
    { 
        get { return idEmployeeNavigation; }
        set
        {
            idEmployeeNavigation = value;
            OnPropertyChanged(nameof(IdEmployeeNavigation));
        }
    }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

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

    [NotMapped]
    public string Name
    {
        get { return $"{IdOrder} {dateOrder}"; }
    }
}
