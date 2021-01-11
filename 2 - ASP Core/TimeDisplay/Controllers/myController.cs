using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers{
    public class myController : Controller{
            [HttpGet]
            [Route("")]
            public IActionResult Index(){
                /*DateTime CurrentTime = DateTime.Now;
                string v = CurrentTime.ToString("h:mm");*/
                return View("Index");
            }
        }
    }
