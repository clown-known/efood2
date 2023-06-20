using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewOfResController : ControllerBase
    {
        private readonly IReviewOfResRepo reviewOfResRepo;

        public ReviewOfResController(IReviewOfResRepo reviewOfResRepo)
        {
            this.reviewOfResRepo = reviewOfResRepo;

        }
        [HttpGet]
        public IActionResult ReviewOfRes()
        {
            ReviewOfResApiModel result = new ReviewOfResApiModel();
            foreach (ReviewOfRe review in reviewOfResRepo.GetAll())
            {
                result.review.Add(new Review { Voting = review.Voting, Comment = review.Comment, Time = review.Time });
            }
            return Ok(result);
        }
    }
}
