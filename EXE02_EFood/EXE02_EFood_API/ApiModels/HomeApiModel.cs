using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.ApiModels
{
    public class HomeApiModel
    {
        public List<CateHome> cate { get; set; }
        public List<Restaurant> res { get; set; }
        public HomeApiModel()
        {
            cate = new List<CateHome>();
            res = new List<Restaurant>();
        }
        
    }
    public class CateHome
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
