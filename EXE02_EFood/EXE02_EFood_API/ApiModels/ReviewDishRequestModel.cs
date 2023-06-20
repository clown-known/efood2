namespace EXE02_EFood_API.ApiModels
{
    public class ReviewDishRequestModel
    {
        public int UserId { get; set; }

        public int? DishId { get; set; }
        public string ReviewContent { get; set; }

        public int? Voting { get; set; }
    }
}
