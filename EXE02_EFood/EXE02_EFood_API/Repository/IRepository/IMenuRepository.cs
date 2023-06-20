using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IMenuRepository
    {
        public Menu Create(Menu menu);
        public List<int> GetDishes(int resId);
        public int GetRes(int dishId);
        public void Delete(Menu menu);
        public List<Menu> GetMenuItemsByRestaurantId(int resId);
    }
}
