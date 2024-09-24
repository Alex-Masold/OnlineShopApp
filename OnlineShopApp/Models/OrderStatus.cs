using OnlineShop.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApp.Models;
public class OrderStatus : PropertyChange
{
    [Key]
    public int IdStatus { get; set; }

    private string? nameStatus;
    public string? NameStatus 
    { 
        get { return nameStatus; }
        set
        {
            nameStatus = value;
            OnPropertyChanged(nameof(NameStatus));
            OnPropertyChanged(nameof(Name));
        }
    }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [NotMapped]
    public string Name
    {
        get { return $"{IdStatus} {nameStatus}"; }
        set
        {
            string[] components = value.Split(' ');
            if (components.Length == 2)
            {
                nameStatus = components[1];
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
