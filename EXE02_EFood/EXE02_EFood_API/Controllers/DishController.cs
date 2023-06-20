using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReviewOfDishRepository _reviewOfDishRepo;
        private readonly IMenuRepository _menuRepository;

        public DishController(IDishRepository dishRepository, IUserRepository userRepository,
            IReviewOfDishRepository reviewOfDishRepository, IMenuRepository menuRepository)
        {
            _dishRepository = dishRepository;
            _userRepository = userRepository;
            _reviewOfDishRepo = reviewOfDishRepository;
            _menuRepository = menuRepository;
        }

        [HttpGet]
        public IActionResult GetAllDishes()
        {
            var dishes = _dishRepository.GetAll();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public IActionResult GetDish(int id)
        {
            var dish = _dishRepository.Get(id);
            if (dish == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Can not get Dish",
                    Data = dish
                });
            }
            return Ok(dish);
        }

        [HttpPost]
        public IActionResult CreateDish(Dish dish)
        {
            _dishRepository.Create(dish);
            return CreatedAtAction(nameof(GetDish), new { id = dish.DishId }, dish);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDish(int id, Dish dish)
        {
            var existingDish = _dishRepository.Get(id);
            if (existingDish == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "Can not update Dish",
                    Data = dish
                });
            }

            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.Price = dish.Price;

            _dishRepository.Update(existingDish);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDish(int id)
        {
            var dish = _dishRepository.Get(id);
            if (dish == null)
            {
                return NotFound();
            }

            _dishRepository.Delete(id);

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchDish(string keyword)
        {
            var dishes = _dishRepository.GetAll().Where(d => d.Name.ToLower().Contains(keyword.ToLower())).ToList();
            if (dishes.Count == 0)
            {
                return NotFound();
            }
            return Ok(dishes);
        }

        [HttpGet("/api/dish/{resId}")]
        public IActionResult GetAllDishOfRestaurant(int resId)
        {
            var menuItems = _menuRepository.GetMenuItemsByRestaurantId(resId);
            if (menuItems.Count == 0)
            {
                return NotFound();
            }

            var dishIds = menuItems.Select(m => m.DishId).ToList();
            var dishes = _dishRepository.GetAll().Where(d => dishIds.Contains(d.DishId)).ToList();

            if (dishes.Count == 0)
            {
                return NotFound();
            }

            return Ok(dishes);
        }


        [HttpGet("/api/dish/review")]
        public IActionResult ReviewOfDish()
        {
            List<ReviewOfDishApiModel> result = new List<ReviewOfDishApiModel>();
            foreach (ReviewOfDish item in _reviewOfDishRepo.GetAll())
            {
                result.Add(new ReviewOfDishApiModel
                {
                    ReviewId = item.ReviewId,
                    DishName = item.Dish.Name,
                    Comment = item.Comment,
                    Time = item.Time.Value.ToString(),
                    UserFullName = item.User.Name,
                    Voting = item.Voting
                });
            }
            return Ok(result);
        }

        [HttpGet("/api/dish/review/{dishId}")]
        public IActionResult GetReviewDishById(int? dishId)
        {
            if (dishId == null)
            {
                return NotFound();
            }
            var reviewDishes = _reviewOfDishRepo.GetReviewDishById((int)dishId);
            if (reviewDishes.Count == 0)
            {
                return NotFound();
            }
            List<ReviewOfDishApiModel> results = new List<ReviewOfDishApiModel>();
            foreach (var item in reviewDishes)
            {
                results.Add(new ReviewOfDishApiModel
                {
                    ReviewId = item.ReviewId,
                    DishName = item.Dish.Name,
                    Comment = item.Comment,
                    Time = item.Time.Value.ToString(),
                    UserFullName = item.User.Name,
                    Voting = item.Voting
                });
            }

            return Ok(results);
        }

        [HttpPost("/api/dish/review")]
        public IActionResult CreateReviewDishById([FromBody] ReviewDishRequestModel model)
        {
            var lastReview = _reviewOfDishRepo.GetLastReview();
            var user = _userRepository.Get(model.UserId);
            var dish = _dishRepository.Get((int)model.DishId);
            ReviewOfDish review = new ReviewOfDish();
            review.ReviewId = lastReview.ReviewId + 1;
            review.UserId = model.UserId;
            review.DishId = model.DishId;
            review.User = user;
            review.Dish = dish;
            review.Comment = model.ReviewContent;
            review.Voting = model.Voting;
            review.Time = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
            review.Status = 1;
            review.IsDeleted = false;

            var res = _reviewOfDishRepo.Create(review);
            ReviewOfDishApiModel result = new ReviewOfDishApiModel();
            result.ReviewId = res.ReviewId;
            result.UserFullName = res.User.Name;
            result.Comment = res.Comment;
            result.Time = res.Time.ToString();
            result.DishName = res.Dish.Name;
            result.Voting = res.Voting;
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("/api/dish/review/{id}")]
        public IActionResult UpdateReviewDishById(int id, [FromBody] ReviewDishRequestModel model)
        {
            var user = _userRepository.Get(model.UserId);
            var dish = _dishRepository.Get((int)model.DishId);
            ReviewOfDish review = new ReviewOfDish();
            review.UserId = model.UserId;
            review.DishId = model.DishId;
            review.User = user;
            review.Dish = dish;
            review.Comment = model.ReviewContent;
            review.Voting = model.Voting;
            review.Time = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
            review.Status = 1;
            review.IsDeleted = false;
            _reviewOfDishRepo.Update(id, review);
            return Ok(model);
        }

        [HttpDelete("/api/dish/review/{id}")]
        public IActionResult DeleteReviewDishById(int id)
        {
            _reviewOfDishRepo.Delete(id);
            return Ok();
        }
    }
}
