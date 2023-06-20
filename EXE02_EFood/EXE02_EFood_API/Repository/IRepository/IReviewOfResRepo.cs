using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IReviewOfResRepo
    {
        public List<ReviewOfRe> GetAll();
    }
}
