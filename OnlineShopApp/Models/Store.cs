using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Printing;

namespace OnlineShopApp.Models;

public partial class Store : PropertyChange
{
    public int IdStore { get; set; }

    private string? cityStore;
    public string? CityStore 
    { 
        get { return cityStore; }
        set
        {
            cityStore = value;
            OnPropertyChanged(nameof(CityStore));
        }
    }

    private string? streetStore;
    public string? StreetStore 
    { 
        get { return streetStore; }
        set
        {
            streetStore = value; 
            OnPropertyChanged(nameof(StreetStore));
        }
    }

    private string? houseStore;
    public string? HouseStore 
    { 
        get { return  houseStore; }
        set
        {
            houseStore = value;
            OnPropertyChanged(nameof(HouseStore));
        }
    }

    private string? numderStore;
    public string? NumberStore 
    { 
        get { return numderStore; }
        set
        {
            numderStore = value;
            OnPropertyChanged(nameof(NumberStore));
        }
    }

    private double? ratingStore;
    public double? RatingStore 
    { 
        get { return ratingStore; }
        set
        {
            ratingStore = value;
            OnPropertyChanged(nameof(RatingStore));
        }
    }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public string Name { get { return CityStore + ' ' + StreetStore +' ' + HouseStore; } }
}
