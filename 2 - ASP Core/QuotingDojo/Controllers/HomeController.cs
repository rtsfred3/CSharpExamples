using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers{
    public class HomeController : Controller{
        public IActionResult Index(){
            DbConnector.Execute("CREATE TABLE IF NOT EXISTS quotes (quote VARCHAR(100), author VARCHAR(100))");
            return View("Index");
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult submitQuotes(string Author, string Quote){
            DbConnector.Execute($"INSERT INTO quotes (quote, author) VALUES (\"{Quote}\", \"{Author}\")");
            return View("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(){
            List<Dictionary<string, object>> quotes = DbConnector.Query("SELECT * FROM quotes");
            ViewBag.quotes = quotes.ToArray();
            // System.Console.WriteLine(quotes.ToArray().Length);
            return View("Quotes");
        }

        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
