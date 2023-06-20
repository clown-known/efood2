namespace EXE02_EFood_API.ApiModels
{
    public class ReviewOfDishApiModel
    {
        public int ReviewId { get; set; }
        public string UserFullName { get; set; }
        public string DishName { get; set; }
        public int? Voting { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }
    }
}
