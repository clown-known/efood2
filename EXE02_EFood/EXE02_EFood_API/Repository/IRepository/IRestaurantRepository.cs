using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IRestaurantRepository
    {
        public Restaurant Get(int id);
        public List<Restaurant> GetAll();
        public void Update(Restaurant res);
        public Restaurant Create(Restaurant res);
        public void Delete(int id);
    }
}
