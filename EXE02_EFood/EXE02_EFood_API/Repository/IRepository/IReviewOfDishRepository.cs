using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IReviewOfDishRepository
    {
        public ReviewOfDish GetReviewById(int id);
        public List<ReviewOfDish> GetAll();
        public List<ReviewOfDish> GetReviewDishById(int id);

        public ReviewOfDish Create(ReviewOfDish reviewOfDish);

        public void Update(int id, ReviewOfDish reviewOfRDish);

        public void Delete(int id);
        public ReviewOfDish GetLastReview();
    }
}
