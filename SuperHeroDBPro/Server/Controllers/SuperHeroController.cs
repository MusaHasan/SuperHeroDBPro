using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SuperHeroDBPro.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic> {                //Damy Data to Show -->
            new Comic { Id = 1, Name = "Marvel"},
            new Comic { Id = 2, Name = "DC"},
        };
        public static List<SuperHero> heroes = new List<SuperHero> { 
            new SuperHero { 
                Id = 1, 
                FirstName = "Peter", 
                LastName = "Parker", 
                HeroName = "Spider-Man", 
                Comic= comics[0]
            },
            new SuperHero { 
                Id = 2, 
                FirstName = "Bruce", 
                LastName = "Wine", 
                HeroName = "Bat-Man", 
                Comic= comics[1]
            },
            
        };                                                                  // <-- Damy Data to Show 

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(heroes);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if(hero == null)
            {
                return NotFound("Sorry No Heros Here");
            }
            return Ok(hero);
        }

    }
}
