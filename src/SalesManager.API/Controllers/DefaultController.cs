using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManager.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        public IActionResult Index()
        {
            return Content("Runing...");
        }
    }
}
