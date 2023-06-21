using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IPremiumRepository
    {
        public Premium Create(Premium premium);
        public Premium Get(int id);
        public List<Premium> GetAll();
        public void Update(Premium premium);
        public void Delete(int id);
    }
}
