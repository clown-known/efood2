using EXE02_EFood_API.Models;
using System;
using System.Collections.Generic;

namespace EXE02_EFood_API.ApiModels
{
    public class ReviewOfResApiModel
    {
        public int ReviewId { get; set; }
        public string UserFullName { get; set; }
        public string RestaurantName { get; set; }
        public int? Voting { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }
    }
}

