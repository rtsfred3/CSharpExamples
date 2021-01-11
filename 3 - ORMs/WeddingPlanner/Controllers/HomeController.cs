using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using WeddingPlanner.Models;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers{
    public class HomeController : Controller{
        private UserContext _context;

        public HomeController(UserContext context){
            _context = context;
        }


        [Route("/")]
        public IActionResult Index(){
            if(HttpContext.Session.GetString("loggedin") == "true"){
                return RedirectToAction("Success");
            }

            ViewData["Title"] = "Login & Registration";

            if(HttpContext.Session.GetInt32("message") == 0){
                if(HttpContext.Session.GetInt32("loginError") == 0){

                }else if(HttpContext.Session.GetInt32("loginError") > 0){
                    if(HttpContext.Session.GetString("errorMessage") != null){
                        @ViewBag.RegistrationError = HttpContext.Session.GetString("errorMessage");
                    }else{
                        @ViewBag.RegistrationError = "There was an error with registration";
                    }
                }
                
                HttpContext.Session.SetInt32("message", -1);
                HttpContext.Session.SetInt32("loginError", -1);
            }

            // List<Wedding> weddingsInDB = _context.Weddings.Include(r => r.User).Include(r => r.UsersRSVP).ToList();
            // List<User> usersInDB = _context.Users.Include(r => r.WeddingsRSVP).ToList();

            // for(var i = 0; i<weddingsInDB.Count; i++){ System.Console.WriteLine(weddingsInDB[i].User.Name); }

            return View("login");
        }

        [Route("/register")]
        public IActionResult Registration(UserValidator userRegister){
            if(ModelState.IsValid){
                User newUser = new User{
                    Name = userRegister.Name,
                    Email = userRegister.Email,
                    Password = userRegister.Password,
                };

                List<User> AllUsers = _context.Users.ToList();

                for(var i = 0; i<AllUsers.Count; i++){
                    if(newUser.Email == AllUsers[i].Email){
                        HttpContext.Session.SetInt32("message", 0);
                        HttpContext.Session.SetInt32("loginError", 1);
                        return RedirectToAction("Index");
                    }
                }

                HttpContext.Session.SetString("Email", newUser.Email);
                HttpContext.Session.SetString("Name", newUser.Name);
                HttpContext.Session.SetString("loggedin", "true");

                _context.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("Success");
            }

            var message = string.Join("<br />", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

            HttpContext.Session.SetInt32("message", 0);
            HttpContext.Session.SetString("errorMessage", message);

            return RedirectToAction("Index");
        }


        [Route("/login")]
        public IActionResult LogIn(string Email, string Password){
            List<User> usersInDB = _context.Users.Where(user => user.Email == Email).ToList();

            if(usersInDB.Count == 0){
                HttpContext.Session.SetInt32("loginError", 0);
                HttpContext.Session.SetInt32("message", 0);
                HttpContext.Session.SetString("errorMessage", "Error with logging in");
                return RedirectToAction("Index");
            }

            HttpContext.Session.SetString("Email", usersInDB[0].Email);
            HttpContext.Session.SetString("Name", usersInDB[0].Name);
            HttpContext.Session.SetString("loggedin", "true");
            
            // 

            return RedirectToAction("Success");
        }

        [Route("/success")]
        public IActionResult Success(){
            if(HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");
            return RedirectToAction("Dashboard");
            // return View("success");
        }

        [Route("/logoff")]
        public IActionResult Logoff(){
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("loggedin", "false");
            return RedirectToAction("Index");
        }

        [Route("/dashboard")]
        public IActionResult Dashboard(){
            if(HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            return View("dashboard");
        }

        [HttpGet]
        [Route("/addWedding")]
        public IActionResult AddWedding(){
            ViewBag.today = DateTime.Now.ToString("yyyy-MM-dd");

            return View("addWedding");
        }

        [HttpPost]
        [Route("/addWedding")]
        public IActionResult PostWedding(){
            ViewBag.today = DateTime.Now.ToString("yyyy-MM-dd");

            return View("addWedding");
        }

        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
