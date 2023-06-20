using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IDishRepository
    {
        public Dish Create(Dish dish);
        public Dish Get(int id);
        public List<Dish> GetAll();
        public void Update(Dish dish);
        public void Delete(int id);
    }
}
