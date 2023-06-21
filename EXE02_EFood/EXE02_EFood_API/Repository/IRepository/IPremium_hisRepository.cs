using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IPremium_hisRepository
    {
        public PremiumHi Create(PremiumHi premiumHis);
        public PremiumHi Get(int premiumHisId);
        public List<PremiumHi> GetByUserId(int userId);
        public void Update(PremiumHi premiumHis);
        public List<PremiumHi> GetAll();
        public void Delete(int premiumHisId);
    }
}
