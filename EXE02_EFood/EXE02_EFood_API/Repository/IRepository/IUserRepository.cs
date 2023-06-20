using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IUserRepository
    {
        public User Create(User user);
        public User Get(int id);
        public List<User> GetAll();
        public void Update(User user);
        public void Delete(int id);
        public User GetByPhone(string phone);
    }
}
