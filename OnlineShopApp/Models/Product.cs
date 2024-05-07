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

    private Provider idProviderNavigation;
    public virtual Provider IdProviderNavigation 
    { 
        get { return idProviderNavigation; }
        set
        {
            idProviderNavigation = value;
            OnPropertyChanged(nameof(IdProviderNavigation));
        }
    }

    private TypesProduct idTypeProductNavigation;
    public virtual TypesProduct IdTypeProductNavigation 
    { 
        get { return idTypeProductNavigation; }
        set
        {
            idTypeProductNavigation = value;
            OnPropertyChanged(nameof(IdTypeProductNavigation));
        }
    }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public string Name {  get { return IdTypeProductNavigation.NameTypeProduct + ' ' + NameProduct; } }
}
