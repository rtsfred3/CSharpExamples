using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Controllers{
    public class HomeController : Controller{
        private ReviewContext _context;

        public HomeController(ReviewContext context){
            _context = context;
        }

        public IActionResult Index(){
            ViewBag.today = DateTime.Now.ToString("yyyy-MM-dd");

            List<Review> reviews = _context.reviews.ToList();
            /*foreach(var review in reviews){
                System.Console.WriteLine(review.date.ToString("yyyy-MM-dd"));
            }*/

            return View();
        }
        
        [HttpPost]
        [Route("/submit_review")]
        public IActionResult post(string name, string restaurant, int stars, string review, string dateVisited){
            // string name, string restaurant, int stars, string review, string dateVisited

            Review newReview = new Review{
                name = name,
                restaurant = restaurant,
                stars = stars,
                review = review,
                date = new DateTime(Convert.ToInt32(dateVisited.Substring(0,4)), Convert.ToInt32(dateVisited.Substring(5,2)), Convert.ToInt32(dateVisited.Substring(8,2)))
            };

            _context.Add(newReview);
            _context.SaveChanges();

            List<Review> reviews = _context.reviews.ToList();
            ViewBag.reviews = reviews.ToArray();
            return RedirectToAction("Reviews", "Home");
        }

        [HttpGet]
        [Route("/reviews")]
        public IActionResult Reviews(string name, string restaurant, int stars, string review, string dateVisited){
            List<Review> reviews = _context.reviews.ToList();
            ViewBag.reviews = reviews.ToArray();
            return View("allReviews");
        }

        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
