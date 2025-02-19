using Microsoft.AspNetCore.Mvc;

namespace Maytab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult<string> Get()=>
            Ok("Hello, World!");

    }
}
