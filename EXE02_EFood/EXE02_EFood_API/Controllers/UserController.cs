using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("api/users")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        [HttpPost]
        [Route("api/users")]
        public IActionResult CreateUser(User user)
        {
            var newUser = _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            var existingUser = _userRepository.Get(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            user.UserId = id;
            _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _userRepository.Get(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);

            return NoContent();
        }
    }

}
