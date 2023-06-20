using System;
using System.ComponentModel.DataAnnotations;

namespace EXE02_EFood_API.ApiModels
{
    public class RestaurantApiModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public TimeSpan? OpenTime { get; set; }
        [Required]
        public int? VoteRating { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal? Lat { get; set; }
        [Required]
        public decimal? Log { get; set; }
        [Required]
        public int? Status { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
