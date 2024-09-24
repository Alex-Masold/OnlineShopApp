using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;

namespace OnlineShopApp.Models;

public partial class OrderDetail : PropertyChange
{
    public int IdDetail { get; set; }

    [NotMapped]
    private int? idOrder;
    public int? IdOrder { 
        get { return idOrder; }
        set
        {
            idOrder = value;
            OnPropertyChanged(nameof(IdOrder));
        }
    }

    [NotMapped]
    private int? idProduct;
    public int? IdProduct { 
        get { return idProduct; }
        set
        {
            idProduct = value;
            OnPropertyChanged(nameof(IdProduct));
        }
    }

    [NotMapped]
    private int? countProduct;
    public int? CountProduct { 
        get { return countProduct; }
        set 
        {
            countProduct = value;
            OnPropertyChanged(nameof(CountProduct));
            OnPropertyChanged(nameof(Price));
        }
    }

    private Order idOrderNavigation;
    public virtual Order IdOrderNavigation 
    { 
        get { return idOrderNavigation; }
        set
        {
            idOrderNavigation = value;
            OnPropertyChanged(nameof(IdOrderNavigation));
        }
    }

    private Product idProductNavigation;
    public virtual Product IdProductNavigation 
    {
        get { return idProductNavigation; }
        set
        {
            idProductNavigation = value;
            OnPropertyChanged(nameof(IdProductNavigation));
        }
    }

    [NotMapped]
    public int Price 
    { 
        get 
        { 
            if (idProductNavigation == null)
                return 0;
            else 
                return (int)(IdProductNavigation.PriceProduct * countProduct); 
        } 
    
    }
}
