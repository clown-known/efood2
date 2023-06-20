using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class CategoryRepositoryImp : ICategoryRepository
    {
        private readonly E_FoodContext _context;

        public CategoryRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Category Create(Category category)
        {
            var newCategory = new Category
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
                IsDeleted = category.IsDeleted
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return newCategory;
        }

        public Category Get(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            return category;
        }

        public List<Category> GetAll()
        {
            var categories = _context.Categories.Where(c => !c.IsDeleted).ToList();
            return categories;
        }

        public void Update(Category category)
        {
            var existingCategory = _context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);

            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                existingCategory.CategoryDescription = category.CategoryDescription;
                existingCategory.IsDeleted = category.IsDeleted;

                _context.Categories.Update(existingCategory);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category != null)
            {
                category.IsDeleted = true;
                _context.Categories.Update(category);
                _context.SaveChanges();
            }
        }
    } 
}
