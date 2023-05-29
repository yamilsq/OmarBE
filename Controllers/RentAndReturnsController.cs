using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rent_a_car_be.Data;
using rent_a_car_be.Dtos;
using rent_a_car_be.Models;

namespace rent_a_car_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentAndReturnsController : ControllerBase
    {
        private readonly rent_a_car_beContext _context;

        public RentAndReturnsController(rent_a_car_beContext context)
        {
            _context = context;
        }

        // GET: api/RentAndReturns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentAndReturnDto>>> GetRentAndReturn()
        {
          if (_context.RentAndReturn == null)
          {
              return NotFound();
          }

            var rentAndReturnDto = new List<RentAndReturnDto>();
            var rentAndReturns = await _context.RentAndReturn
                                        .Include(x => x.Car)
                                        .Include(x => x.Employee)
                                        .Include(x => x.Client)
                                    .ToListAsync();

            foreach (var inspection in rentAndReturns)
            {
                rentAndReturnDto.Add(new RentAndReturnDto
                {
                    Id = inspection.Id,
                    Status = inspection.Status,
                    CarId = inspection.CarId,
                    ClientId = inspection.ClientId,
                    EmployeeId = inspection.EmployeeId,
                    EmployeeName = inspection.Employee.Name,
                    ClientName = inspection.Client.Name,
                    CarDescription = inspection.Car.Description,
                    RentDate = inspection.RentDate,
                    ReturnDate = inspection.ReturnDate,
                    AmountDay = inspection.AmountDay,
                    Days = inspection.Days,
                    Comment = inspection.Comment,
                    CarInspectionId = inspection.CarInspectionId,
                });
            }

            return rentAndReturnDto;
        }

        // GET: api/RentAndReturns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentAndReturn>> GetRentAndReturn(int id)
        {
          if (_context.RentAndReturn == null)
          {
              return NotFound();
          }
            var rentAndReturn = await _context.RentAndReturn.FindAsync(id);

            if (rentAndReturn == null)
            {
                return NotFound();
            }

            return rentAndReturn;
        }

        // PUT: api/RentAndReturns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentAndReturn(int id, RentAndReturn rentAndReturn)
        {
            if (id != rentAndReturn.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentAndReturn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentAndReturnExists(id))
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

        // POST: api/RentAndReturns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<bool>> PostRentAndReturn(RentAndReturn rentAndReturn)
        {
            try
            {
                if (_context.RentAndReturn == null)
                {
                    return Problem("Entity set 'rent_a_car_beContext.RentAndReturn'  is null.");
                }
                _context.RentAndReturn.Add(rentAndReturn);
                var car = _context.Car.FirstOrDefault(x => x.Id == rentAndReturn.CarId);

                if (car != null)
                    car.Status = 0;

                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // DELETE: api/RentAndReturns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentAndReturn(int id)
        {
            if (_context.RentAndReturn == null)
            {
                return NotFound();
            }
            var rentAndReturn = await _context.RentAndReturn.FindAsync(id);
            if (rentAndReturn == null)
            {
                return NotFound();
            }

            _context.RentAndReturn.Remove(rentAndReturn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentAndReturnExists(int id)
        {
            return (_context.RentAndReturn?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
