using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class DishRepositoryImp : IDishRepository
    {
        private readonly E_FoodContext _context;

        public DishRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Dish Create(Dish dish)
        {
            var newDish = new Dish
            {
                Name = dish.Name,
                Image = dish.Image,
                VoteRating = dish.VoteRating,
                Price = dish.Price,
                Description = dish.Description,
                Status = dish.Status,
                IsDeleted = dish.IsDeleted
            };

            _context.Dishes.Add(newDish);
            _context.SaveChanges();

            return newDish;
        }

        public Dish Get(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(d => d.DishId == id);
            return dish;
        }

        public List<Dish> GetAll()
        {
            var dishes = _context.Dishes.Where(d => !d.IsDeleted).ToList();
            return dishes;
        }

        public void Update(Dish dish)
        {
            var existingDish = _context.Dishes.SingleOrDefault(d => d.DishId == dish.DishId);

            if (existingDish != null)
            {
                existingDish.Name = dish.Name;
                existingDish.Image = dish.Image;
                existingDish.VoteRating = dish.VoteRating;
                existingDish.Price = dish.Price;
                existingDish.Description = dish.Description;
                existingDish.Status = dish.Status;
                existingDish.IsDeleted = dish.IsDeleted;

                _context.Dishes.Update(existingDish);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(d => d.DishId == id);

            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
            }
        }
    }

}
