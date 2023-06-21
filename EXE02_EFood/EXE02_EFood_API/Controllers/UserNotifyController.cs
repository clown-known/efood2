using EXE02_EFood_API.BusinessObject;
using EXE02_EFood_API.Models;
using EXE02_EFood_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotifyController : ControllerBase
    {
        private readonly IUserNotifyRepository _userNotifyRepository;

        public UserNotifyController(IUserNotifyRepository userNotifyRepository)
        {
            _userNotifyRepository = userNotifyRepository;
        }

        [HttpGet]
        public IActionResult GetAllUserNotifies()
        {
            var userNotifies = _userNotifyRepository.GetAll();
            return Ok(userNotifies);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserNotify(int userId)
        {
            var userNotify = _userNotifyRepository.GetOfUser(userId);
            if (userNotify == null)
            {
                return NotFound(new ResponseObject
                {
                    Message = "User notify not found",
                    Data = userNotify
                });
            }

            return Ok(userNotify);
        }

        [HttpPost]
        public IActionResult CreateUserNotify(UserNotify userNotify)
        {
            var newUserNotify = _userNotifyRepository.Create(userNotify);
            return CreatedAtAction(nameof(GetUserNotify),
                new { userId = newUserNotify.UserId, notifyId = newUserNotify.NotifyId }, newUserNotify);
        }


        [HttpDelete("{userId}/{notifyId}")]
        public IActionResult DeleteUserNotify(int userId, int notifyId)
        {
            _userNotifyRepository.Delete(userId, notifyId);

            return NoContent();
        }
    }

}
