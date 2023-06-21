using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IUserNotifyRepository
    {
        public void Delete(int userId, int notifyId);
        public void Update(UserNotify userNotify);
        public List<UserNotify> GetAll();
        public List<UserNotify> GetOfUser(int userId);

        public UserNotify Create(UserNotify userNotify);
    }
}
