using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_a_car_be.Data;
using rent_a_car_be.Models;

namespace rent_a_car_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private readonly rent_a_car_beContext _context;

        public CarTypesController(rent_a_car_beContext context)
        {
            _context = context;
        }

        // GET: api/CarTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarType()
        {
          if (_context.CarType == null)
          {
              return NotFound();
          }
            return await _context.CarType.ToListAsync();
        }

        // GET: api/CarTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarType(int id)
        {
          if (_context.CarType == null)
          {
              return NotFound();
          }
            var carType = await _context.CarType.FindAsync(id);

            if (carType == null)
            {
                return NotFound();
            }

            return carType;
        }

        // PUT: api/CarTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarType(int id, CarType carType)
        {
            if (id != carType.Id)
            {
                return BadRequest();
            }

            _context.Entry(carType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarTypeExists(id))
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

        // POST: api/CarTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarType>> PostCarType(CarType carType)
        {
          if (_context.CarType == null)
          {
              return Problem("Entity set 'rent_a_car_beContext.CarType'  is null.");
          }
            _context.CarType.Add(carType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarType", new { id = carType.Id }, carType);
        }

        // DELETE: api/CarTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarType(int id)
        {
            if (_context.CarType == null)
            {
                return NotFound();
            }
            var carType = await _context.CarType.FindAsync(id);
            if (carType == null)
            {
                return NotFound();
            }

            _context.CarType.Remove(carType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarTypeExists(int id)
        {
            return (_context.CarType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
