using EXE02_EFood_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EXE02_EFood_API.Controllers
{
    public class RestaurantManagerController : Controller
    {
        RestaurantRepositoryImp _res;
        public RestaurantManagerController(RestaurantRepositoryImp res)
        {
            _res = res;
        }

        public IActionResult Index()
        {
            var result = _res.GetAll();
            return View(result);
        }
    }
}
