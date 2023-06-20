using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IDishCategoryRepository
    {
        public DishCategory Create(DishCategory dishCategory);
        public List<int> GetDishCategories(int dishId);
        public List<int> GetDishesByCategory(int categoryId);
        public void Delete(DishCategory dishCategory);

    }
}
