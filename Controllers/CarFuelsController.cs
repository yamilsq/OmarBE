using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_a_car_be.Data;
using rent_a_car_be.Models;

namespace rent_a_car_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFuelsController : ControllerBase
    {
        private readonly rent_a_car_beContext _context;

        public CarFuelsController(rent_a_car_beContext context)
        {
            _context = context;
        }

        // GET: api/CarFuels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarFuel>>> GetCarFuel()
        {
          if (_context.CarFuel == null)
          {
              return NotFound();
          }
            return await _context.CarFuel.ToListAsync();
        }

        // GET: api/CarFuels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarFuel>> GetCarFuel(int id)
        {
          if (_context.CarFuel == null)
          {
              return NotFound();
          }
            var carFuel = await _context.CarFuel.FindAsync(id);

            if (carFuel == null)
            {
                return NotFound();
            }

            return carFuel;
        }

        // PUT: api/CarFuels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarFuel(int id, CarFuel carFuel)
        {
            if (id != carFuel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carFuel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarFuelExists(id))
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

        // POST: api/CarFuels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarFuel>> PostCarFuel(CarFuel carFuel)
        {
          if (_context.CarFuel == null)
          {
              return Problem("Entity set 'rent_a_car_beContext.CarFuel'  is null.");
          }
            _context.CarFuel.Add(carFuel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarFuel", new { id = carFuel.Id }, carFuel);
        }

        // DELETE: api/CarFuels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarFuel(int id)
        {
            if (_context.CarFuel == null)
            {
                return NotFound();
            }
            var carFuel = await _context.CarFuel.FindAsync(id);
            if (carFuel == null)
            {
                return NotFound();
            }

            _context.CarFuel.Remove(carFuel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarFuelExists(int id)
        {
            return (_context.CarFuel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
