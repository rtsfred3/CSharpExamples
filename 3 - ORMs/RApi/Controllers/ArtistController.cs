using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RApi.Models;

namespace RApi.Controllers{
    public class ArtistController : Controller{

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [HttpGet]
        [Route("")]
        public string Index(){
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [HttpGet]
        [Route("/artists")]
        public IEnumerable<Artist> Artists(){
            return allArtists.Where(prod => true);
        }

        [HttpGet]
        [Route("/artists/Name/{str}")]
        public IEnumerable<Artist> ArtistName(string str){
            IEnumerable<Artist> limitedArtists = allArtists.Where(prod => prod.ArtistName.ToLower().Contains(str.ToLower()));
            return limitedArtists;
        }

        [HttpGet]
        [Route("/artists/RealName/{str}")]
        public IEnumerable<Artist> ArtistRealName(string str){
            IEnumerable<Artist> limitedArtists = allArtists.Where(prod => prod.RealName.ToLower().Contains(str.ToLower()));
            return limitedArtists;
        }

        [HttpGet]
        [Route("/artists/Hometown/{str}")]
        public IEnumerable<Artist> ArtistHometown(string str){
            IEnumerable<Artist> limitedArtists = allArtists.Where(prod => prod.Hometown.Contains(str));
            return limitedArtists;
        }

        [HttpGet]
        [Route("/artists/GroupId/{num}")]
        public IEnumerable<Artist> ArtistGroupId(int num){
            IEnumerable<Artist> limitedArtists = allArtists.Where(prod => prod.GroupId == num);
            return limitedArtists;
        }
    }
}
