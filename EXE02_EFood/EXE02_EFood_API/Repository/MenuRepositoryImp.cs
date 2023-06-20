using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class MenuRepositoryImp : IMenuRepository
    {
        private readonly E_FoodContext _context;

        public MenuRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Menu Create(Menu menu)
        {
            var newMenu = new Menu
            {
                ResId = menu.ResId,
                DishId = menu.DishId,
                IsDeleted = menu.IsDeleted
            };

            _context.Menus.Add(newMenu);
            _context.SaveChanges();

            return newMenu;
        }

        public List<int> GetDishes(int resId)
        {
            var dishIds = _context.Menus
                .Where(m => m.ResId == resId && !m.IsDeleted)
                .Select(m => m.DishId)
                .ToList();

            return dishIds;
        }

        public int GetRes(int dishId)
        {
            var resIds = _context.Menus
                .Where(m => m.DishId == dishId && !m.IsDeleted)
                .Select(m => m.ResId)
                .FirstOrDefault();

            return resIds;
        }

        public void Delete(Menu menu)
        {
            var existingMenu = _context.Menus
                .SingleOrDefault(m => m.ResId == menu.ResId && m.DishId == menu.DishId);

            if (existingMenu != null)
            {
                _context.Menus.Remove(existingMenu);
                _context.SaveChanges();
            }
        }
    }

}
