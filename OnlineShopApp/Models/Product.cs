using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Product : PropertyChange
{
    [NotMapped]
    private int idProduct;
    public int IdProduct 
    { 
        get { return idProduct; }
        set
        {
            idProduct = value;
            OnPropertyChanged(nameof(IdProduct));
        }
    }

    [NotMapped]
    private string? nameProduct;
    public string? NameProduct 
    { 
        get { return nameProduct; }
        set 
        { 
            nameProduct = value;
            OnPropertyChanged(nameof(NameProduct));
        }
    }

    [NotMapped]
    private int? quantityProduct;
    public int? QuantityProduct 
    { 
        get { return quantityProduct; }
        set
        {
            quantityProduct = value;
            OnPropertyChanged(nameof(QuantityProduct));
        }
    }

    [NotMapped]
    private int? idProvider;
    public int? IdProvider 
    { 
        get { return idProvider; }
        set
        {
            idProvider = value;
            OnPropertyChanged(nameof(IdProvider));
        }
    }

    [NotMapped]
    private double? ratingProduct;
    public double? RatingProduct 
    { 
        get { return  ratingProduct; }
        set
        {
            ratingProduct = value;
            OnPropertyChanged(nameof(RatingProduct));
        }
    }

    [NotMapped]
    private int? idTypeProduct;
    public int? IdTypeProduct 
    { 
        get { return idTypeProduct; }
        set
        {
            idTypeProduct = value;
            OnPropertyChanged(nameof(IdTypeProduct));
        }
    }

    [NotMapped]
    private int? priceProduct;
    public int? PriceProduct 
    { 
        get { return priceProduct; }
        set
        {
            priceProduct = value;
            OnPropertyChanged(nameof(PriceProduct));
        }
    }

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual TypesProduct IdTypeProductNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public string Name {  get { return IdTypeProductNavigation.NameTypeProduct + ' ' + NameProduct; } }
    [NotMapped]
    public ObservableCollection<OrderDetail> ObservableOrderDetails { get { return new ObservableCollection<OrderDetail>(OrderDetails); } }

}
