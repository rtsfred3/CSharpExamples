using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RApi.Models;

namespace RApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet]
        [Route("/groups")]
        public IEnumerable<Group> Artists(){
            return allGroups.Where(prod => true);
        }

        [HttpGet]
        [Route("/groups/Name/{str}")]
        public IEnumerable<Group> ArtistGroupId(string str){
            return allGroups.Where(prod => prod.GroupName.ToLower().Contains(str.ToLower()));
        }

        [HttpGet]
        [Route("/groups/GroupId/{num}")]
        public IEnumerable<Group> ArtistGroupId(int num){
            return allGroups.Where(prod => prod.Id == num);
        }
    }
}
