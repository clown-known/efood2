namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IActiveCode
    {
        public string GetActiveCode(string mail);
        public void CreateActiveCode(string mail,string code);
    }
}
