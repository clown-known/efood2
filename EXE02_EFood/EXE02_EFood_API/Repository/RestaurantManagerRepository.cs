using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class RestaurantManagerRepository : IRestaurantManagerRepository
    {
        private readonly E_FoodContext _context;

        public RestaurantManagerRepository(E_FoodContext context)
        {
            _context = context;
        }

        public RestaurantManager Create(RestaurantManager restaurantManager)
        {
            _context.RestaurantManagers.Add(restaurantManager);
            _context.SaveChanges();
            return restaurantManager;
        }

        public RestaurantManager Get(int id)
        {
            return _context.RestaurantManagers.FirstOrDefault(rm => rm.ResManagerId == id && rm.IsDeleted!=true);
        }

        public List<RestaurantManager> GetAll()
        {
            return _context.RestaurantManagers.Where(rm => rm.IsDeleted != true).ToList();
        }

        public void Update(RestaurantManager restaurantManager)
        {
            _context.RestaurantManagers.Update(restaurantManager);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurantManager = _context.RestaurantManagers.FirstOrDefault(rm => rm.ResManagerId == id);
            if (restaurantManager != null)
            {
                restaurantManager.IsDeleted = true;
                _context.RestaurantManagers.Update(restaurantManager);
                _context.SaveChanges();
            }
        }
    }

}
