
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Data;
using WineAPI.Models;

namespace WeinAPI.Controllers
{
    //api/winebymanufactuer
    [Route("api/deleteEveryThing")]
    [ApiController]
    public class DeleteEveryThing : ControllerBase
    {
        private readonly WineContext _context;

        public DeleteEveryThing(WineContext context)
        {
            _context = context;
        }
 //     GET api/winebymanufactuer/{token}
        [HttpDelete("{token}")]
        public ActionResult deleteEveryThing(string token)
        {
            var wines = _context.Wines.ToList();
            var manufactuers = _context.Manufactuers.ToList();
            var addresses = _context.Addresses.ToList();

            if (token.Equals("$69420çH3llo2cönt"))
            {
                foreach (var wine in wines)
                {
                    _context.Remove(wine);    
                }
                foreach (var manufactuer in manufactuers)
                {
                    _context.Remove(manufactuer);    
                }
                foreach (var address in addresses)
                {
                    _context.Remove(address);    
                }
                _context.SaveChanges();
                return NoContent();
            }
            return Conflict("False Token");            
        }

    }
}
