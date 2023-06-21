using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class UserNotifyRepositoryImp : IUserNotifyRepository
    {
        private readonly E_FoodContext _context;

        public UserNotifyRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public UserNotify Create(UserNotify userNotify)
        {
            var newUserNotify = new UserNotify
            {
                UserId = userNotify.UserId,
                NotifyId = userNotify.NotifyId,
                Status = userNotify.Status,
                IsDeleted = userNotify.IsDeleted
            };

            _context.UserNotifies.Add(newUserNotify);
            _context.SaveChanges();

            return newUserNotify;
        }

        public List<UserNotify> GetOfUser(int userId)
        {
            var userNotify = _context.UserNotifies
                .Where(un => un.UserId == userId).ToList();

            return userNotify;
        }

        public List<UserNotify> GetAll()
        {
            var userNotifies = _context.UserNotifies.ToList();
            return userNotifies;
        }

        public void Update(UserNotify userNotify)
        {
            var existingUserNotify = _context.UserNotifies
                .SingleOrDefault(un => un.UserId == userNotify.UserId && un.NotifyId == userNotify.NotifyId);

            if (existingUserNotify == null)
            {
                return;
            }

            existingUserNotify.Status = userNotify.Status;
            existingUserNotify.IsDeleted = userNotify.IsDeleted;

            _context.UserNotifies.Update(existingUserNotify);
            _context.SaveChanges();
        }

        public void Delete(int userId, int notifyId)
        {
            var userNotify = _context.UserNotifies
                .SingleOrDefault(un => un.UserId == userId && un.NotifyId == notifyId);

            if (userNotify != null)
            {
                _context.UserNotifies.Remove(userNotify);
                _context.SaveChanges();
            }
        }
    }

}
