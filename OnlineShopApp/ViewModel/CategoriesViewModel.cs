using OnlineShop.Models.Base;
using OnlineShop.Models.Data;
using OnlineShopApp.DataSource;
using OnlineShopApp.Models;
using System.Collections.ObjectModel;

namespace OnlineShopApp.ViewModel
{
    class CategoriesViewModel : PropertyChange
    {
        private ApplicationContext db = new ApplicationContext();
        public ObservableCollection<Category> Categories { get; set; }
        public CategoriesViewModel() 
        { 
            Categories = StaticData.GetAllCategories(db);
        }
    }
}
