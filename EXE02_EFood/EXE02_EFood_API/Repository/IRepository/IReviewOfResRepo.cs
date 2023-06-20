using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IReviewOfResRepo
    {
        public ReviewOfRe GetReviewById(int id);
        public List<ReviewOfRe> GetAll();
        public List<ReviewOfRe> GetReviewResById(int id);

        public ReviewOfRe Create(ReviewOfRe reviewOfRe);

        public void Update(int id, ReviewOfRe reviewOfReview);

        public void Delete(int id);
        public ReviewOfRe GetLastReview();
    }
}
