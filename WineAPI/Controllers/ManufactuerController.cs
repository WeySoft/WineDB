
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Data;
using WineAPI.Models;

namespace WeinAPI.Controllers
{
    //api/manufactuer
    [Route("api/manufactuer")]
    [ApiController]
    public class ManufactuerController : ControllerBase
    {
        private readonly WineContext _context;

        public ManufactuerController(WineContext context)
        {
            _context = context;
        }

        // GET api/manufactuer
        [HttpGet]
        public ActionResult <IEnumerable<Manufactuer>> GetAllManufactuer()
        {
            var manufactuers = _context.Manufactuers.Include(m => m.address).ToList();
            return Ok(manufactuers);
        }

        // GET api/manufactuer/{id}
        [HttpGet("{id}", Name="GetManufactuerById")]
        public ActionResult <Manufactuer>  GetManufactuerById(long Id)
        {
            var manufactuer = _context.Manufactuers.Include(m => m.address).FirstOrDefault(m => m.Id == Id);
            if(manufactuer != null){
            return Ok(manufactuer);
            }
            return NotFound();
        }
        
        // POST api/manufactuer/
        [HttpPost]
        public ActionResult <Manufactuer> CreateWine(Manufactuer manufactuer)
        {     
            Address address = _context.Addresses.Find(manufactuer.address.Id); 

            if (address != null)
            {
                manufactuer.address = address;
            }

            _context.Manufactuers.Add(manufactuer);
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetManufactuerById), new {Id = manufactuer.Id}, manufactuer);
        }

        //Put api/manufactuer/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateManufactuer(int id, Manufactuer manufactuerUpdate)
        {
            
            var manufactuerUnupdate = _context.Manufactuers.FirstOrDefault(w => w.Id == id);
            if (manufactuerUnupdate != null)
            {
                    manufactuerUnupdate.Name = manufactuerUpdate.Name;

                    _context.SaveChanges();
                    return NoContent();
                
            }
            else
            {
                return NotFound();
            }
        }

       
        //Delete api/manufactuer/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteManufactuer(long id)
        {
            var deleteManufactuer = _context.Manufactuers.FirstOrDefault(w => w.Id == id);     
            if(deleteManufactuer == null)
            {
                return NotFound();
            }
            _context.Manufactuers.Remove(deleteManufactuer);
            _context.SaveChanges();
            return NoContent();
        }

    }
}