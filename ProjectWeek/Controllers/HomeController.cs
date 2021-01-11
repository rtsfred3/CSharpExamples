using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProjectWeek.Models;

using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace ProjectWeek.Controllers{
    public class HomeController : Controller{
        private VideoContext _context;

        public HomeController(VideoContext context){
            _context = context;
        }

        public IActionResult Index(){
            List<Video> videos = _context.Video.ToList();
            for(var i = 0; i<videos.Count; i++){
                System.Console.WriteLine(videos[i].title);
            }
            return View();
        }

        [Route("/v/{id}")]
        public IActionResult Video(string id){
            List<Video> video = _context.Video.Where(u => u.keyId == id).ToList();
            if(video.Count != 1){
                return RedirectToAction("Index");
            }
            ViewData["filename"] = video[0].filename;
            ViewData["Title"] = video[0].title;
            ViewBag.isVideo = "0";
            return View("Video");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
