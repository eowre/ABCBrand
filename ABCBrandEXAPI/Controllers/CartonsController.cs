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
        private const string okay = "OK"; //defining constants
        private const string notOkay = "NOTOK";
        private readonly AbContext _context; // database context

        public CartonsController(AbContext context) //adding context to controller
        {
            _context = context;
        }

        // GET: api/Cartons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartonDTO>>> GetCartons() //general get method to return all cartons
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
        public async Task<ActionResult<IEnumerable<CartonDTO>>> GetOkCartons() // get method for all OK status cartons
        {
            if (_context.Cartons == null) //checking for null database
            {
                return NotFound();
            }
            var cartons = await _context.Cartons.Where(c => c.Status == okay).Select(c =>  // using LINQ to convert Carton into Carton DTO
                new CartonDTO() 
                { 
                    Id = c.Id,
                    Status = c.Status,
                    ArtNum = c.ArtNum,
                    Quantity = c.Quantity
                }).ToListAsync();
            return Ok(cartons); // returning HTTP response code
        }

        // GET: api/Cartons/NotOk
        [HttpGet("NotOkStatus")]
        public async Task<ActionResult<IEnumerable<CartonDTO>>> GetNotOkCartons() // GET method for all NOTOK status catoon
        {
            if (_context.Cartons == null) //checking for null database
            {
                return NotFound();
            }
            var cartons = await _context.Cartons.Where(c => c.Status == notOkay).Select(c => // using LINQ to convert Carton in Carton DTO
            new CartonDTO 
            {
                Id = c.Id,
                Status = c.Status,
                ArtNum = c.ArtNum,
                Quantity = c.Quantity
            }).ToListAsync();
            return Ok(cartons); //returning http response
        }

        // GET: api/Cartons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartonDTO>> GetCarton(int id) // Get a specific carton by ID
        {
          if (_context.Cartons == null) // checking for null Database
          {
              return NotFound();
          }
            var carton = await _context.Cartons.Select(c => //using LINQ to convert to DTO
            new CartonDTO() 
            {
                Id = c.Id,
                Status = c.Status,
                ArtNum = c.ArtNum,
                Quantity = c.Quantity
            }).SingleOrDefaultAsync();

            if (carton == null) // enmsuring proper response if no such carton exsists 
            {
                return NotFound();
            }

            return carton; // returning HTTP response code
        }

        // PUT: api/Cartons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarton(int id, CartonDTO dto)  // Put method to alter carton
        {
            var carton = new Carton() //building carton from the supllied carton dto
            {
                Id = dto.Id,
                Status = dto.Status.ToUpper(),
                ArtNum = dto.ArtNum,
                Quantity = dto.Quantity
            };
            if (id != carton.Id) // ensureing provided id and carton ID match
            {
                return BadRequest();
            }

            _context.Entry(carton).State = EntityState.Modified; // modifying stored carton

            try
            {
                await _context.SaveChangesAsync(); // waiting for db to save
            }
            catch (DbUpdateConcurrencyException)  // catching erros
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

            return NoContent(); // returning nothing 204 response
        }

        // POST: api/Cartons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carton>> PostCarton(CartonDetailsDTO dto) //POST method for new carton
        {
            if (_context.Cartons == null) // checking that the DBset is no null
            {
                return Problem("Entity set 'AbContext.Cartons'  is null.");
            }
            var carton = new Carton() // building cartoon from the detailDTO
            {
                Status = dto.Status.ToUpper(),
                ArtNum= dto.ArtNum,
                Quantity= dto.Quantity
            };
            _context.Cartons.Add(carton); // adding to the db

            await _context.SaveChangesAsync(); //saving cahnges

            return CreatedAtAction("GetCarton", new { id = carton.Id }, carton); //returning newly created DTO
        }

        // DELETE: api/Cartons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarton(int id) // deleting carton by ID
        {
            if (_context.Cartons == null) // checking for null DB
            {
                return NotFound();
            }
            var carton = await _context.Cartons.FindAsync(id); //finding carton to delete
            if (carton == null)
            {
                return NotFound(); // checking if carton found
            }

            _context.Cartons.Remove(carton); //removing carton from db
            await _context.SaveChangesAsync(); // saving DB

            return NoContent(); //returng 2044
        }

        private bool CartonExists(int id) // helper functions
        {
            return (_context.Cartons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
