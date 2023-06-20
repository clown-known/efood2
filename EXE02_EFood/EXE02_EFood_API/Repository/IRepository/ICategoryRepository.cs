using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Category Create(Category category);
        public Category Get(int id);
        public List<Category> GetAll();
        public void Update(Category category);
        public void Delete(int id);
    }
}
