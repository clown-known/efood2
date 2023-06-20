using EXE02_EFood_API.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.ApiModels
{
    public class ResdetailApiModel
    {
        public Restaurant resInfor { get; set; }
        public List<Dish> dishList { get; set; }
        public ResdetailApiModel()
        {
            dishList = new List<Dish>();
        }
    }
}
