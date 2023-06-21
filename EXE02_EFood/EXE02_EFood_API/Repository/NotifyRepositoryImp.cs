using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class NotifyRepositoryImp : INotifyRepository
    {
        private readonly E_FoodContext _context;

        public NotifyRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public Notify Create(Notify notify)
        {
            var newNotify = new Notify
            {
                ResId = notify.ResId,
                Detail = notify.Detail,
                ToUserId = notify.ToUserId,
                Description = notify.Description,
                Status = notify.Status,
                IsDeleted = notify.IsDeleted
            };

            _context.Notifies.Add(newNotify);
            _context.SaveChanges();

            return newNotify;
        }

        public Notify Get(int id)
        {
            var notify = _context.Notifies.SingleOrDefault(n => n.NotifyId == id && !n.IsDeleted);
            return notify;
        }
        public List<Notify> GetOfRes(int id)
        {
            var notify = _context.Notifies.Where(n => n.ResId == id && !n.IsDeleted).ToList();
            return notify;
        }

        public List<Notify> GetAll()
        {
            var notifies = _context.Notifies.Where(n => !n.IsDeleted).ToList();
            return notifies;
        }

        public void Update(Notify notify)
        {
            var existingNotify = _context.Notifies.SingleOrDefault(n => n.NotifyId == notify.NotifyId);
            if (existingNotify == null)
            {
                return;
            }

            existingNotify.Detail = notify.Detail;
            existingNotify.ToUserId = notify.ToUserId;
            existingNotify.Description = notify.Description;
            existingNotify.Status = notify.Status;
            existingNotify.IsDeleted = notify.IsDeleted;

            _context.Notifies.Update(existingNotify);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var notify = _context.Notifies.SingleOrDefault(n => n.NotifyId == id);
            if (notify != null)
            {
                notify.IsDeleted = true;
                _context.Notifies.Update(notify);
                _context.SaveChanges();
            }
        }
    }

}
