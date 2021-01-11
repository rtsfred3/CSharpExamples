using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers{
    public class myController : Controller{
        LocalDictionary[] locations = new LocalDictionary[]{
            new LocalDictionary("san_jose", "San Jose"),
            new LocalDictionary("seattle", "Seattle"),
            new LocalDictionary("los_angeles", "Los Angeles"),
            new LocalDictionary("dallas", "Dallas"),
            new LocalDictionary("tysons_corner", "Tysons Corner"),
            new LocalDictionary("chicago", "Chicago"),
            new LocalDictionary("tulsa", "Tulsa"),
            new LocalDictionary("east_bay", "East Bay")
        };
                
        LocalDictionary[] languages = new LocalDictionary[]{
            new LocalDictionary("java", "Java"),
            new LocalDictionary("javascript", "Javascript"),
            new LocalDictionary("python", "Python"),
            new LocalDictionary("php", "PHP"),
            new LocalDictionary("ruby", "Ruby"),
            new LocalDictionary("c++", "C++"),
            new LocalDictionary("c", "C"),
            new LocalDictionary("c#", "C#")
        };

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.locations = this.locations;
            ViewBag.languages = this.languages;
                
            return View("survey");
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Results(string name, string location, string language, string comments){
            ViewBag.name = name;
            ViewBag.comment = comments;
            ViewBag.language = "";
            ViewBag.location = "";

            for(var i = 0; i<this.locations.Length; i++){
                if(this.locations[i].id == location){
                    ViewBag.location = this.locations[i].name;
                    break;
                }
            }

            for(var i = 0; i<this.languages.Length; i++){
                if(this.languages[i].id == language){
                    ViewBag.language = this.languages[i].name;
                    break;
                }
            }
            return View("result");
        }
    }
}