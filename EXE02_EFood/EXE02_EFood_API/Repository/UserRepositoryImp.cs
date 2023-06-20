using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class UserRepositoryImp : IUserRepository
    {
        private readonly E_FoodContext _context;

        public UserRepositoryImp(E_FoodContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            var newUser = new User
            {
                Name = user.Name,
                Avatar = user.Avatar,
                Phone = user.Phone,
                IsPremium = false,
                Status = user.Status,
                IsDeleted = false
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public User Get(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id && u.IsDeleted != true);
            return user;
        }
        public User GetByPhone(string phone)
        {
            var user = _context.Users.SingleOrDefault(u => u.Phone.Equals(phone) && u.IsDeleted!=true);
            return user;
        }

        public List<User> GetAll()
        {
            var users = _context.Users.Where(u => !u.IsDeleted).ToList();
            return users;
        }

        public void Update(User user)
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.UserId == user.UserId);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Avatar = user.Avatar;
                existingUser.Phone = user.Phone;
                existingUser.IsPremium = user.IsPremium;
                existingUser.Status = user.Status;
                existingUser.IsDeleted = user.IsDeleted;

                _context.Users.Update(existingUser);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id);

            if (user != null)
            {
                user.IsDeleted = true;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }
    }

}
