using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;

        public DishController(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
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
    }
}
