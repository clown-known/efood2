namespace EXE02_EFood_API.ApiModels
{
    public class ReviewRequestModel
    {
        public int UserId { get; set; }

        public int? ResId { get; set; }
        public string ReviewContent { get; set; }

        public int? Voting { get; set; }
    }
}
