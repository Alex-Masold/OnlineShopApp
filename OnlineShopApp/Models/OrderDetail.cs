using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Input;

namespace OnlineShopApp.Models;

public partial class OrderDetail : PropertyChange
{
    [NotMapped]
    private int idDetail;
    public int IdDetail {
        get {  return idDetail; } 
        set 
        {
            idDetail = value;
            OnPropertyChanged(nameof(IdDetail));
        }
    }

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
        }
    }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public int Price 
    { 
        get 
        { 
            return (int)(IdProductNavigation.PriceProduct * CountProduct); 
        } 
    
    }
}
