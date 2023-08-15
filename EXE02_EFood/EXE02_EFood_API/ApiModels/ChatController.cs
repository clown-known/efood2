using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE02_EFood_API.ApiModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpGet]
        public IActionResult getCode()
        {
            return Ok("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");
        }
    }
}
