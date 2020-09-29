
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Data;
using WineAPI.Models;

namespace WeinAPI.Controllers
{
    //api/winebymanufactuer
    [Route("api/winebymanufactuer")]
    [ApiController]
    public class WineByManufactuerController : ControllerBase
    {
        private readonly WineContext _context;

        public WineByManufactuerController(WineContext context)
        {
            _context = context;
        }
 //     GET api/winebymanufactuer/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Wine>> GetAllWineByManufactuer(long id)
        {
            var wines = _context.Wines.Include(w => w.manufactuer.address).ToList();
            var wineswithManufactuer = wines.Where(w => w.manufactuer.Id == id).ToList();

            if(wineswithManufactuer == null)
            {
                return Conflict("No Wines");
            }          
            return Ok(wineswithManufactuer);
        }

    }
}
