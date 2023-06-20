using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class ReviewOfResRepoImp : IReviewOfResRepo
    {
        private readonly E_FoodContext _context;
        public ReviewOfResRepoImp(E_FoodContext context)
        {
            _context = context;
        }

        public ReviewOfRe Create(ReviewOfRe reviewOfRe)
        {
            _context.ReviewOfRes.Add(reviewOfRe);
            _context.SaveChanges();
            return reviewOfRe;
        }

        public void Delete(int id)
        {
            var review = _context.ReviewOfRes.SingleOrDefault(r => r.ReviewId == id);
            if (review != null)
            {
                review.IsDeleted = true;
                _context.ReviewOfRes.Update(review);
                _context.SaveChanges();
            }
        }

        public List<ReviewOfRe> GetAll()
        {
            var result = _context.ReviewOfRes.Include(res => res.Res).Include(res => res.User).Where(i => i.IsDeleted != true && i.Status == 1).ToList();
            return result;
        }

        public ReviewOfRe GetReviewById(int id)
        {
            return _context.ReviewOfRes.Include(res => res.Res).Include(res => res.User).SingleOrDefault(res => res.ReviewId == id && res.IsDeleted!=true);
        }

        //Lay Review Bang restaurant Id
        public List<ReviewOfRe> GetReviewResById(int id)
        {
            var result = _context.ReviewOfRes.Include(res => res.Res).Include(res => res.User).Where(res => res.ResId == id).ToList();
            return result;
        }

        public void Update(int id, ReviewOfRe reviewOfReview)
        {
            var review = _context.ReviewOfRes.SingleOrDefault(r => r.ReviewId == id);
            if (review != null)
            {
                review.ResId = reviewOfReview.ResId;
                review.UserId = reviewOfReview.UserId;
                review.Voting = reviewOfReview.Voting;
                review.Comment = reviewOfReview.Comment;
                _context.ReviewOfRes.Update(review);
                _context.SaveChanges();
            }
        }

        public ReviewOfRe GetLastReview()
        {
            return _context.ReviewOfRes.Where(a=>a.IsDeleted!= true).ToList().Last();
        }
    }
}
