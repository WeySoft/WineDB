
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineAPI.Data;
using WineAPI.Models;

namespace WeinAPI.Controllers
{
    //api/address
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly WineContext _context;

        public AddressController(WineContext context)
        {
            _context = context;
        }

        // GET api/address
        [HttpGet]
        public ActionResult <IEnumerable<Address>> GetAllAddress()
        {
            var AddressItems = _context.Addresses.ToList();

            return Ok(AddressItems);
        }

        // GET api/address/{id}
        [HttpGet("{id}", Name="GetAddressById")]
        public ActionResult <Address>  GetAddressById(int Id)
        {
            var AddressItem = _context.Addresses.FirstOrDefault(a => a.Id == Id);
            if(AddressItem != null){
            return Ok(AddressItem);
            }
            return NotFound();
        }
        
        // POSt api/address/
        [HttpPost]
        public ActionResult <Address> CreateAddress(Address addressCreate)
        {     
            
            
            var address = _context.Addresses.Find(addressCreate.Id); 
            if (address == null)
            {
                _context.Addresses.Add(addressCreate);
                _context.SaveChanges();

                return CreatedAtRoute(nameof(GetAddressById), new {Id = addressCreate.Id}, addressCreate);
            }
            return Conflict("Address already exits");
        }

        //Put api/address/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAddress(int id, Address addressUpdate)
        {
            
            var addressUnupdate = _context.Addresses.FirstOrDefault(w => w.Id == id);
            if (addressUnupdate != null)
            {
                    addressUnupdate.Land = addressUpdate.Land;
                    addressUnupdate.Location = addressUpdate.Location;
                    addressUnupdate.PostalCode = addressUpdate.PostalCode;
                    _context.SaveChanges();
                    return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

       
        //Delete api/address/{id}
        [HttpDelete("{id}")]
        public ActionResult deleteAddress(long id)
        {
            var deleteAddress = _context.Addresses.FirstOrDefault(a => a.Id == id);     
            if(deleteAddress == null)
            {
                return NotFound();
            }
            _context.Addresses.Remove(deleteAddress);
            _context.SaveChanges();
            return NoContent();
        }

    }
}