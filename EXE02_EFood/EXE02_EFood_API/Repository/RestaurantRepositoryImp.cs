using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Xml.Linq;

namespace EXE02_EFood_API.Repository
{
    public class RestaurantRepositoryImp : IRestaurantRepository
    {
        private readonly E_FoodContext _context;
        public RestaurantRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Restaurant Create(Restaurant res)
        {
            var acc = new Restaurant
            {
                Name = res.Name,
                District = res.District,
                Address = res.Address,
                Image = res.Image,
                Price = res.Price,
                OpenTime = res.OpenTime,
                VoteRating = res.VoteRating,
                Description = res.Description,
                Lat = res.Lat,
                Log = res.Log,
                Status = 1,
                IsDeleted = true,
            };
            _context.Restaurants.Add(acc);
            _context.SaveChanges();
            return acc;
        }

        public Restaurant Get(int id)
        {
            var result = _context.Restaurants.SingleOrDefault(a => a.ResId == id &&a.IsDeleted != true);
            return result;
        }
        public List<Restaurant> GetAll()
        {
            var result = _context.Restaurants.Where(i=>i.IsDeleted!=true).ToList();
            return result;
        }

        public void Update(Restaurant res)
        {
            var acc = _context.Restaurants.SingleOrDefault(a => a.ResId == res.ResId);
            acc.Name = res.Name;
            acc.District = res.District;
            acc.Address = res.Address;
            acc.Image = res.Image;
            acc.Price = res.Price;
            acc.OpenTime = res.OpenTime;
            acc.VoteRating = res.VoteRating;
            res .Description = res.Description;
            acc.Lat = res.Lat;
            acc.Log = res.Log;
            acc .Status = res.Status;
            acc.IsDeleted = true;
            _context.Restaurants.Update(acc);
            _context.SaveChanges(); 
        }

        List<Restaurant> IRestaurantRepository.GetAll()
        {
            var result = _context.Restaurants.ToList();
            return result;
        }

        public void Delete(int id)
        {
            var acc = _context.Restaurants.SingleOrDefault(a => a.ResId == id);
            if (acc != null)
            {
                acc.IsDeleted = true;
                _context.Restaurants.Update(acc);
                _context.SaveChanges();
            }   
        }




    }
}
