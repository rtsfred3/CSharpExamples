using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers{
    public class myController : Controller{
            [HttpGet]
            [Route("")]
            public IActionResult Index(){
                return View("Index");
            }

            [HttpGet]
            [Route("projects")]
            public IActionResult Projects(){
                return View("Projects");
            }

            [HttpGet]
            [Route("contact")]
            public IActionResult Contact(){
                return View("Contact");
            }
        }
    }
