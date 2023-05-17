using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABCBrandEXAPI.Data;
using ABCBrandEXAPI.Models;

namespace ABCBrandEXAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartonsController : ControllerBase
    {
        private const string okay = "OK";
        private const string notOkay = "NOTOK";
        private readonly AbContext _context;

        public CartonsController(AbContext context)
        {
            _context = context;
        }

        // GET: api/Cartons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartonDTO>>> GetCartons()
        {
          if (_context.Cartons == null) // Checking for a null Database 
          {
              return NotFound();  // return NotFound
          }

            var Cartons = await _context.Cartons.Select(c => // Using a LINQ Query to convert Carton into Carton DTO 
                new CartonDTO()
                {
                    Id = c.Id,
                    Status = c.Status,
                    ArtNum = c.ArtNum,
                    Quantity = c.Quantity
                }).ToListAsync();

          return Ok(Cartons); // returning 200 response status code.
        }

        // GET: api/Cartons/Ok
        [HttpGet("OkStatus")]
        public async Task<ActionResult<IEnumerable<CartonDTO>>> GetOkCartons()
        {
            if (_context.Cartons == null)
            {
                return NotFound();
            }
            var cartons = await _context.Cartons.Where(c => c.Status == okay).Select(c => 
                new CartonDTO() 
                { 
                    Id = c.Id,
                    Status = c.Status,
                    ArtNum = c.ArtNum,
                    Quantity = c.Quantity
                }).ToListAsync();
            return Ok(cartons);
        }

        // GET: api/Cartons/NotOk
        [HttpGet("NotOkStatus")]
        public async Task<ActionResult<IEnumerable<CartonDTO>>> GetNotOkCartons()
        {
            if (_context.Cartons == null)
            {
                return NotFound();
            }
            var cartons = await _context.Cartons.Where(c => c.Status == notOkay).Select(c => 
            new CartonDTO 
            {
                Id = c.Id,
                Status = c.Status,
                ArtNum = c.ArtNum,
                Quantity = c.Quantity
            }).ToListAsync();
            return Ok(cartons);
        }

        // GET: api/Cartons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartonDTO>> GetCarton(int id)
        {
          if (_context.Cartons == null)
          {
              return NotFound();
          }
            var carton = await _context.Cartons.Select(c => 
            new CartonDTO() 
            {
                Id = c.Id,
                Status = c.Status,
                ArtNum = c.ArtNum,
                Quantity = c.Quantity
            }).SingleOrDefaultAsync();

            if (carton == null)
            {
                return NotFound();
            }

            return carton;
        }

        // PUT: api/Cartons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarton(int id, CartonDTO dto)
        {
            var carton = new Carton()
            {
                Id = dto.Id,
                Status = dto.Status.ToUpper(),
                ArtNum = dto.ArtNum,
                Quantity = dto.Quantity
            };
            if (id != carton.Id)
            {
                return BadRequest();
            }

            _context.Entry(carton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cartons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carton>> PostCarton(CartonDetailsDTO dto)
        {
            if (_context.Cartons == null)
            {
                return Problem("Entity set 'AbContext.Cartons'  is null.");
            }
            var carton = new Carton()
            {
                Status = dto.Status.ToUpper(),
                ArtNum= dto.ArtNum,
                Quantity= dto.Quantity
            };
            _context.Cartons.Add(carton);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarton", new { id = carton.Id }, carton);
        }

        // DELETE: api/Cartons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarton(int id)
        {
            if (_context.Cartons == null)
            {
                return NotFound();
            }
            var carton = await _context.Cartons.FindAsync(id);
            if (carton == null)
            {
                return NotFound();
            }

            _context.Cartons.Remove(carton);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartonExists(int id)
        {
            return (_context.Cartons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
