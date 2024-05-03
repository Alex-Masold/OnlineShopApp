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
    public string? Status { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [NotMapped]
    public ObservableCollection<Order> ObservableOrders { get { return new ObservableCollection<Order>(Orders); } }

    public string Name { get { return Status + ' ' + '(' + IdStatus + ')'; } }



}
