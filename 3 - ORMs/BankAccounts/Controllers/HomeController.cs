using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;

namespace BankAccounts.Controllers{
    public class HomeController : Controller{
        [HttpGet]
        [Route("/")]
        public IActionResult Index(){
            return View("login");
        }

        [HttpGet]
        [Route("/account/{}")]
        public IActionResult Login(){
            return View("login");
        }

        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
