using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopApp.Models;
public class OrderStatus : PropertyChange
{
    [Key]
    public int IdStatus { get; set; }

    private string? status;
    public string? Status 
    { 
        get { return status; }
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(Name));
        }
    }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [NotMapped]
    public string Name
    {
        get { return $"{IdStatus} {status}"; }
        set
        {
            string[] components = value.Split(' ');
            if (components.Length == 2)
            {
                status = components[1];
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
