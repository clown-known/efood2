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
        public List<ReviewOfRe> GetAll()
        {
            var result = _context.ReviewOfRes.Where(i => i.IsDeleted != true).ToList();
            return result;
        }
    }
}
