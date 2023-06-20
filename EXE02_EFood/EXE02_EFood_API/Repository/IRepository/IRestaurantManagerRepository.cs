using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IRestaurantManagerRepository
    {
        public void Delete(int id);
        public void Update(RestaurantManager restaurantManager);
        public List<RestaurantManager> GetAll();
        public RestaurantManager Get(int id);
        public RestaurantManager Create(RestaurantManager restaurantManager);
    }
}
