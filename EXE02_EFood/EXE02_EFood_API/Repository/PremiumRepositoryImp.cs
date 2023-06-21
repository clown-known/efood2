using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EXE02_EFood_API.Repository
{
    public class PremiumRepositoryImp : IPremiumRepository
    {
        private readonly E_FoodContext _context;

        public PremiumRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Premium Create(Premium premium)
        {
            var newPremium = new Premium
            {
                Period = premium.Period,
                Value = premium.Value
            };

            _context.Premium.Add(newPremium);
            _context.SaveChanges();

            return newPremium;
        }

        public Premium Get(int id)
        {
            var premium = _context.Premium.FirstOrDefault(p => p.PremiumId == id);
            return premium;
        }

        public List<Premium> GetAll()
        {
            var premiums = _context.Premium.ToList();
            return premiums;
        }

        public void Update(Premium premium)
        {
            var existingPremium = _context.Premium.FirstOrDefault(p => p.PremiumId == premium.PremiumId);
            if (existingPremium == null)
            {
                return;
            }

            existingPremium.Period = premium.Period;
            existingPremium.Value = premium.Value;


            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var premium = _context.Premium.FirstOrDefault(p => p.PremiumId == id);
            if (premium == null)
            {
                throw new ArgumentException("Premium not found");
            }

            _context.Premium.Remove(premium);
            _context.SaveChanges();
        }
    }

}
