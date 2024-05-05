using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;

public partial class Product : PropertyChange
{
    public int IdProduct { get; set; }

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

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual TypesProduct IdTypeProductNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public string Name {  get { return IdTypeProductNavigation.NameTypeProduct + ' ' + NameProduct; } }
    [NotMapped]
    public ObservableCollection<OrderDetail> ObservableOrderDetails { get { return new ObservableCollection<OrderDetail>(OrderDetails); } }

    [NotMapped]
    private bool isEditName;
    [NotMapped]
    public bool IsEditName
    {
        get { return isEditName; }
        set
        {
            isEditName = value;
            OnPropertyChanged(nameof(IsEditName));
        }
    }

    [NotMapped]
    private bool isEditQuantity;
    [NotMapped]
    public bool IsEditQuantity
    {
        get { return isEditQuantity; }
        set
        {
            isEditQuantity = value;
            OnPropertyChanged(nameof(IsEditQuantity));
        }
    }

    [NotMapped]
    private bool isEditRating;
    [NotMapped]
    public bool IsEditRating
    {
        get { return isEditRating; }
        set
        {
            isEditRating = value;
            OnPropertyChanged(nameof(IsEditRating));
        }
    }

    [NotMapped]
    private bool isEditPrice;
    [NotMapped]
    public bool IsEditPrice
    {
        get { return isEditPrice; }
        set
        {
            isEditPrice = value;
            OnPropertyChanged(nameof(IsEditPrice));
        }
    }
}
