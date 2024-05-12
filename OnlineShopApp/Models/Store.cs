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
            OnPropertyChanged(nameof(Name));
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
            OnPropertyChanged(nameof(Name));
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
            OnPropertyChanged(nameof(Name));
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
            OnPropertyChanged(nameof(Name));
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

    [NotMapped]
    public string Name
    {
        get { return $"{cityStore} {streetStore} {houseStore} {numderStore}"; }
        set
        {
            string[] components = value.Split(' ');
            if (components.Length == 4)
            {
                cityStore = components[0];
                streetStore = components[1];
                houseStore = components[2];
                numderStore = components[3];
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
