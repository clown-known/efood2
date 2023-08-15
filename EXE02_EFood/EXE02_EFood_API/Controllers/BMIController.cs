using EXE02_EFood_API.ApiModels;
using EXE02_EFood_API.BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE02_EFood_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BMIController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetBMI(BMIApiModel bmi)
        {
            return Ok(new ResponseObject
            {
                Success = true,
                Data = bmi.getResult()
            });
        }
        
    }

}
