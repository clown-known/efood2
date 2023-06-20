using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class ReviewOfDishRepositoryImp : IReviewOfDishRepository
    {
        private readonly E_FoodContext _context;    
        public ReviewOfDishRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public ReviewOfDish Create(ReviewOfDish reviewOfDish)
        {
            _context.ReviewOfDishes.Add(reviewOfDish);
            _context.SaveChanges();
            return reviewOfDish;
        }

        public void Delete(int id)
        {
            var review = _context.ReviewOfDishes.SingleOrDefault(r => r.ReviewId == id);
            if (review != null)
            {
                _context.ReviewOfDishes.Remove(review);
                _context.SaveChanges();
            }
        }

        public List<ReviewOfDish> GetAll()
        {
            var result = _context.ReviewOfDishes.Include(res => res.Dish).Include(res => res.User).Where(i => i.IsDeleted != true && i.Status == 1).ToList();
            return result;
        }

        public ReviewOfDish GetReviewById(int id)
        {
            return _context.ReviewOfDishes.Include(res => res.Dish).Include(res => res.User).SingleOrDefault(res => res.ReviewId == id);
        }

        //Lay Review Bang restaurant Id
        public List<ReviewOfDish> GetReviewDishById(int id)
        {
            var result = _context.ReviewOfDishes.Include(res => res.Dish).Include(res => res.User).Where(res => res.DishId == id).ToList();
            return result;
        }

        public void Update(int id, ReviewOfDish reviewOfReview)
        {
            var review = _context.ReviewOfDishes.SingleOrDefault(r => r.ReviewId == id);
            if (review != null)
            {
                review.DishId = reviewOfReview.DishId;
                review.UserId = reviewOfReview.UserId;
                review.Voting = reviewOfReview.Voting;
                review.Comment = reviewOfReview.Comment;
                _context.ReviewOfDishes.Update(review);
                _context.SaveChanges();
            }
        }

        public ReviewOfDish GetLastReview()
        {
            return _context.ReviewOfDishes.ToList().Last();
        }
    }
}
