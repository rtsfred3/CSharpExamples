using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BeltExam.Models;

using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers{
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
                    if(HttpContext.Session.GetString("errorMessage") != null){
                        @ViewBag.LoginError = HttpContext.Session.GetString("errorMessage");
                    }else{
                        @ViewBag.LoginError = "There was an error with logging in";
                    }
                }else if(HttpContext.Session.GetInt32("loginError") == 1){
                    if(HttpContext.Session.GetString("errorMessage") != null){
                        @ViewBag.RegistrationError = HttpContext.Session.GetString("errorMessage");
                    }else{
                        @ViewBag.RegistrationError = "There was an error with registration";
                    }
                }
                
                HttpContext.Session.SetInt32("message", -1);
                HttpContext.Session.SetInt32("loginError", -1);
            }

            return View("login");
        }

        [HttpPost]
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

                _context.Add(newUser);
                _context.SaveChanges();

                List<User> usersInDB = _context.Users.Where(user => user.Email == newUser.Email).ToList();

                HttpContext.Session.SetString("UserId", usersInDB[0].UserId.ToString());
                HttpContext.Session.SetString("Email", newUser.Email);
                HttpContext.Session.SetString("Name", newUser.Name);
                HttpContext.Session.SetString("loggedin", "true");

                return RedirectToAction("Success");
            }

            var message = string.Join("<br />", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

            HttpContext.Session.SetInt32("message", 0);
            HttpContext.Session.SetString("errorMessage", message);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult LogIn(string Email, string Password){
            List<User> usersInDB = _context.Users.Where(user => user.Email == Email).ToList();

            if(usersInDB.Count == 0 || usersInDB[0].Password != Password){
                HttpContext.Session.SetInt32("loginError", 0);
                HttpContext.Session.SetInt32("message", 0);
                HttpContext.Session.SetString("errorMessage", "Error with logging in");

                return RedirectToAction("Index");
            }

            HttpContext.Session.SetString("UserId", usersInDB[0].UserId.ToString());
            HttpContext.Session.SetString("Email", usersInDB[0].Email);
            HttpContext.Session.SetString("Name", usersInDB[0].Name);
            HttpContext.Session.SetString("loggedin", "true");

            return RedirectToAction("Success");
        }

        [Route("/success")]
        public IActionResult Success(){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
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

        [HttpGet]
        [Route("/new")]
        public IActionResult NewActivity(){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            if(HttpContext.Session.GetInt32("message") == 0){
                ViewBag.ErrorMessage = HttpContext.Session.GetString("errorMessage");
                HttpContext.Session.SetInt32("message", -1);
            }

            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            ViewBag.today = DateTime.Now.ToString("yyyy-MM-dd HH:mm:00").Replace(' ', 'T');
            return View("newActivity");
        }

        [HttpPost]
        [Route("/new")]
        public IActionResult PostActivity(DojoActivityValidator activityData){
            if(ModelState.IsValid && activityData.DurationTime > 0){
                List<User> usersInDB = _context.Users.Where(user => user.Email == HttpContext.Session.GetString("Email")).ToList();
                
                string datePlanned = activityData.Date;

                DojoActivity newActivity = new DojoActivity{
                    Title = activityData.Title,
                    Date = new DateTime(Convert.ToInt32(datePlanned.Substring(0,4)), Convert.ToInt32(datePlanned.Substring(5,2)), Convert.ToInt32(datePlanned.Substring(8,2)), Convert.ToInt32(datePlanned.Substring(11,2)), Convert.ToInt32(datePlanned.Substring(14,2)), 0),
                    Duration = activityData.DurationTime + " " + activityData.DurationUnits,
                    Description = activityData.Description,

                    UserId = usersInDB[0].UserId
                };

                _context.Add(newActivity);
                _context.SaveChanges();

                List<DojoActivity> activitiesInDB = _context.DojoActivity.Where(activity => activity.UserId == usersInDB[0].UserId).Where(activity => activity.Title == newActivity.Title).Where(activity => activity.Date == newActivity.Date).ToList();

                System.Console.WriteLine(activitiesInDB.Count);

                return RedirectToAction("ShowActivity", new { id = activitiesInDB[0].DojoActivityId });
            }

            var message = string.Join("<br />", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

            if(activityData.DurationTime <= 0){
                message += "\nDuration must be larger than zero";
            }

            

            HttpContext.Session.SetInt32("message", 0);
            HttpContext.Session.SetString("errorMessage", message);

            return RedirectToAction("NewActivity");
        }

        [HttpGet]
        [Route("/activity/{id}")]
        public IActionResult ShowActivity(int? id){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            ViewBag.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            List<DojoActivity> activitiesInDB = _context.DojoActivity.Where(a => a.DojoActivityId == Convert.ToInt32(id)).Include(u => u.User).Include(u => u.UserActivity).ThenInclude(u => u.User).ToList();

            if(activitiesInDB.Count == 0){
                return RedirectToAction("Dashboard");
            }

            ViewBag.Activity = activitiesInDB[0];

            return View("activity");
        }

        [HttpPost]
        [Route("/activity/{id}/join")]
        public IActionResult JoinActivity(int? id){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            ViewBag.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            List<DojoActivity> activitiesInDB = _context.DojoActivity.Where(a => a.DojoActivityId == Convert.ToInt32(id)).Include(u => u.User).Include(u => u.UserActivity).ToList();

            if(activitiesInDB.Count == 0){
                return RedirectToAction("ShowActivity", new { id = activitiesInDB[0].DojoActivityId });
            }
            
            UserActivity userActivity = new UserActivity{
                UserId = ViewBag.UserId,
                DojoActivityId = activitiesInDB[0].DojoActivityId
            };

            _context.Add(userActivity);
            _context.SaveChanges();

            return RedirectToAction("ShowActivity", new { id = activitiesInDB[0].DojoActivityId });
        }

        [HttpPost]
        [Route("/activity/{id}/leave")]
        public IActionResult LeaveActivity(int? id){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            UserActivity userActivity = _context.UserActivity.SingleOrDefault(a => a.DojoActivityId == Convert.ToInt32(id) && a.UserId == userId) ?? null;

            if(userActivity == null){
                return RedirectToAction("ShowActivity", new { id = Convert.ToInt32(id) });
            }
            
            _context.UserActivity.Remove(userActivity);
            _context.SaveChanges();

            return RedirectToAction("ShowActivity", new { id = Convert.ToInt32(id) });
        }

        [HttpPost]
        [Route("/activity/{id}/delete")]
        public IActionResult DeleteActivity(int? id){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            DojoActivity dojoActivity = _context.DojoActivity.SingleOrDefault(u => u.DojoActivityId == Convert.ToInt32(id)) ?? null;
            
            if(dojoActivity == null){
                return RedirectToAction("Dashboard");
            }

            List<UserActivity> userActivities = _context.UserActivity.Where(a => a.DojoActivityId == Convert.ToInt32(id)).ToList();

            for(var i = 0; i<userActivities.Count; i++){
                _context.UserActivity.Remove(userActivities[i]);
            }

            _context.DojoActivity.Remove(dojoActivity);
            
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard(){
            if(HttpContext.Session.GetString("loggedin") == null || HttpContext.Session.GetString("loggedin") == "false"){
                return RedirectToAction("Index");
            }

            ViewBag.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.LoggedIn = HttpContext.Session.GetString("loggedin");

            List<DojoActivity> activitiesInDB = _context.DojoActivity.Where(u => DateTime.Now.CompareTo(u.Date) < 0).Include(u => u.User).Include(u => u.UserActivity).OrderBy(x => x.Date).ToList();

            ViewBag.Activities = activitiesInDB;

            return View("dashboard");
        }

        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
