
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Data;
using WineAPI.Models;

namespace WeinAPI.Controllers
{
    //api/commands
    [Route("api/wine")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly WineContext _context;

        public WineController(WineContext context)
        {
            _context = context;
        }

        // GET api/wine
        [HttpGet]
        public ActionResult <IEnumerable<Wine>> GetAllWine()
        {
            var wineItems = _context.Wines.Include(w => w.manufactuer.address).ToList();
            return Ok(wineItems);
        }

        // GET api/wine/{id}
        [HttpGet("{id}", Name="GetWineById")]
        public ActionResult <Wine>  GetWineById(int Id)
        {
            var wineItem = _context.Wines.Include(w => w.manufactuer).FirstOrDefault(w => w.Id == Id);
            if(wineItem != null){
            return Ok(wineItem);
            }
            return NotFound();
        }
        
        // POSt api/wine/
        [HttpPost]
        public ActionResult <Wine> CreateWine(Wine wineCreate)
        {     
            

            var manufactuer = wineCreate.manufactuer; 
            wineCreate.manufactuer = _context.Manufactuers.Find(wineCreate.manufactuer.Id); 
            if (wineCreate.manufactuer == null)
            {
                wineCreate.manufactuer = manufactuer;
            }
            _context.Wines.Add(wineCreate);
            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetWineById), new {Id = wineCreate.Id}, wineCreate);
        }

        //Put api/wine/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateWine(int id, Wine wineUpdate)
        {
            
            var wineUnupdate = _context.Wines.FirstOrDefault(w => w.Id == id);
            if (wineUnupdate != null)
            {
                    wineUnupdate.Name = wineUpdate.Name;
                    wineUnupdate.color = wineUpdate.color;
                    wineUnupdate.price = wineUpdate.price;
                    wineUnupdate.grape = wineUpdate.grape;
                    wineUnupdate.spaceID = wineUpdate.spaceID;
                    wineUnupdate.year = wineUpdate.year;
                    wineUnupdate.amount = wineUpdate.amount;
                    _context.SaveChanges();
                    return NoContent();
                
            }
            else
            {
                return NotFound();
            }
        }

       
        //Delete api/wine/{id}
        [HttpDelete("{id}")]
        public ActionResult Deletewine(long id)
        {
            var deleteWine = _context.Wines.FirstOrDefault(w => w.Id == id);     
            if(deleteWine == null)
            {
                return NotFound();
            }
            _context.Wines.Remove(deleteWine);
            _context.SaveChanges();
            return NoContent();
        }

    }
}