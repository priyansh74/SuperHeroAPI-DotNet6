using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {   
        
        private readonly DataContext _context;

        public SuperHeroController(DataContext context )
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get() //Get call -> return success code && heroes response.
        {
            return Ok( await _context.SuperHeroes.ToArrayAsync() ); //this returns all the heroes
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id) //Get call -> return success code && heroes response.
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if(hero == null)
                return BadRequest("Hero not found, wrong Id");
            return Ok(hero); //this returns the specific heroe
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero) //Post call -> return success code && add val;
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request) //Put call -> return success code && edit changes;
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
                return BadRequest("Hero not found, wrong Id");
            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName; 
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _context.SaveChangesAsync();
            return Ok( await _context.SuperHeroes.ToListAsync() );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id) //Delete call -> return success code && heroes left after deleting.
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found, wrong ID");
            _context.SuperHeroes.Remove(dbHero);
            
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }


    }
}
