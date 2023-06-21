using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface INotifyRepository
    {
        public List<Notify> GetOfRes(int id);
        public Notify Get(int id);
        public List<Notify> GetAll();
        public void Delete(int id);
        public void Update(Notify notify);
        public Notify Create(Notify notify);
    }
}
