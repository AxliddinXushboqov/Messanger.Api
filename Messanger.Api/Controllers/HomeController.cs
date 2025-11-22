using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Messanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult SayHello() =>
            Ok("Hellooo!");
    }
}