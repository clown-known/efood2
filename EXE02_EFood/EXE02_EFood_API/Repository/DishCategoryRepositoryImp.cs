using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class DishCategoryRepositoryImp : IDishCategoryRepository
    {
        private readonly E_FoodContext _context;

        public DishCategoryRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public DishCategory Create(DishCategory dishCategory)
        {
            var newDishCategory = new DishCategory
            {
                DishId = dishCategory.DishId,
                CategoryId = dishCategory.CategoryId
            };

            _context.DishCategories.Add(newDishCategory);
            _context.SaveChanges();

            return newDishCategory;
        }

        public List<int> GetDishCategories(int dishId)
        {
            var categoryIds = _context.DishCategories
                .Where(dc => dc.DishId == dishId && !dc.IsDeleted)
                .Select(dc => dc.CategoryId)
                .ToList();

            return categoryIds;
        }

        public List<int> GetDishesByCategory(int categoryId)
        {
            var dishIds = _context.DishCategories
                .Where(dc => dc.CategoryId == categoryId&&!dc.IsDeleted)
                .Select(dc => dc.DishId)
                .ToList();

            return dishIds;
        }

        public void Delete(DishCategory dishCategory)
        {
            var existingDishCategory = _context.DishCategories
                .SingleOrDefault(dc => dc.DishId == dishCategory.DishId && dc.CategoryId == dishCategory.CategoryId);

            if (existingDishCategory != null)
            {
                existingDishCategory.IsDeleted = true;
                _context.DishCategories.Update(existingDishCategory);
                _context.SaveChanges();
            }
        }
    }

}
