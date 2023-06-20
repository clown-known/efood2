using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class ActiveCodeRepositoryImp : IActiveCode
    {
        private readonly E_FoodContext _context;
        public ActiveCodeRepositoryImp()
        {
            _context = new E_FoodContext();
        }
        public void CreateActiveCode(string mail, string code)
        {
            if (GetActiveCode(mail) != null)
            {
                var e = _context.ActiveCodes.SingleOrDefault(e=>e.Email.Equals(mail));
                e.Code = code;
                _context.ActiveCodes.Update(e);
                _context.SaveChanges();
                return;
            }
            _context.ActiveCodes.Add(new ActiveCode
            {
                Code = code+"",
                Email = mail
            });
            _context.SaveChanges();
        }

        public string GetActiveCode(string mail)
        {
            ActiveCode a = _context.ActiveCodes.SingleOrDefault(a => a.Email.Equals(mail));
            if(a == null) return null;
            return a.Code;
        }
    }
}
