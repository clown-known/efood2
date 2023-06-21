using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class Premium_hisRepositoryImp : IPremium_hisRepository
    {
        private readonly E_FoodContext _context;
        public Premium_hisRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public PremiumHi Create(PremiumHi premiumHis)
        {
            var premiumHisEntry = _context.PremiumHis.Add(premiumHis);
            _context.SaveChanges();
            return premiumHisEntry.Entity;
        }

        public PremiumHi Get(int premiumHisId)
        {
            return _context.PremiumHis.FirstOrDefault(ph => ph.PremiumId == premiumHisId);
        }

        public List<PremiumHi> GetByUserId(int userId)
        {
            return _context.PremiumHis.Where(ph => ph.UserId == userId).ToList();
        }
        public List<PremiumHi> GetAll()
        {
            return _context.PremiumHis.ToList();
        }
        

        public void Update(PremiumHi premiumHis)
        {
            _context.PremiumHis.Update(premiumHis);
            _context.SaveChanges();
        }

        public void Delete(int premiumHisId)
        {
            var premiumHis = Get(premiumHisId);
            if (premiumHis != null)
            {
                _context.PremiumHis.Remove(premiumHis);
                _context.SaveChanges();
            }
        }
    }

}
