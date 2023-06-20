using EXE02_EFood_API.Models;
using System;
using System.Collections.Generic;

namespace EXE02_EFood_API.ApiModels
{
    public class ReviewOfResApiModel
    {
        public List<Review> review { get; set; }
        public ReviewOfResApiModel()
        {
            review = new List<Review>();
        }

    }
    public class Review
    {
        public int? Voting { get; set; }
        public string Comment { get; set; }
        public TimeSpan? Time { get; set; }
    }
}

