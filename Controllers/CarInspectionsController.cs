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
    public class CarInspectionsController : ControllerBase
    {
        private readonly rent_a_car_beContext _context;

        public CarInspectionsController(rent_a_car_beContext context)
        {
            _context = context;
        }

        // GET: api/CarInspections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarInspectionDto>>> GetCarInspection()
        {
          if (_context.CarInspection == null)
          {
              return NotFound();
          }

            var carInspectionsDto = new List<CarInspectionDto>();
            var inspections = await _context.CarInspection
                                        .Include(x => x.Car)
                                        .Include(x => x.Employee)
                                        .Include(x => x.Client)
                                    .ToListAsync();

            foreach (var inspection in inspections)
            {
                var hasRent = _context.RentAndReturn.FirstOrDefault(x => x.CarInspectionId == inspection.Id)?.Id;

                carInspectionsDto.Add(new CarInspectionDto
                {
                    Id = inspection.Id,
                    Status = inspection.Status,
                    IsScratched = inspection.IsScratched,
                    HasSpareWheel = inspection.HasSpareWheel,
                    HasGato = inspection.HasGato,
                    HasGlassBreaks = inspection.HasGlassBreaks,
                    TopLeftWheel = inspection.TopLeftWheel,
                    TopRightWheel = inspection.TopRightWheel,
                    BottomLeftWheel = inspection.BottomLeftWheel,
                    BottomRightWheel = inspection.BottomRightWheel,
                    FuelQuantity = inspection.FuelQuantity,
                    InspectionDate = inspection.InspectionDate,
                    EventType = inspection.EventType,
                    CarId = inspection.CarId,
                    ClientId = inspection.ClientId,
                    EmployeeId = inspection.EmployeeId,
                    EmployeeName = inspection.Employee.Name,
                    ClientName = inspection.Client.Name,
                    CarDescription = inspection.Car.Description,
                    HasRent = hasRent
                });
            }

            return carInspectionsDto;
        }

        // GET: api/CarInspections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarInspection>> GetCarInspection(int id)
        {
          if (_context.CarInspection == null)
          {
              return NotFound();
          }
            var carInspection = await _context.CarInspection.FindAsync(id);

            if (carInspection == null)
            {
                return NotFound();
            }

            return carInspection;
        }

        // PUT: api/CarInspections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarInspection(int id, CarInspection carInspection)
        {
            if (id != carInspection.Id)
            {
                return BadRequest();
            }

            _context.Entry(carInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarInspectionExists(id))
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

        // POST: api/CarInspections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarInspection>> PostCarInspection(CarInspection carInspection)
        {
            try
            {
                if (_context.CarInspection == null)
                    return Problem("Entity set 'rent_a_car_beContext.CarInspection'  is null.");
                
                _context.CarInspection.Add(carInspection);

                if (carInspection.EventType == 2) {
                    var car = _context.Car.FirstOrDefault(x => x.Id == carInspection.CarId);
                    if (car != null)
                        car.Status = 1;
                }

                await _context.SaveChangesAsync();

                return Ok(true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // DELETE: api/CarInspections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarInspection(int id)
        {
            if (_context.CarInspection == null)
            {
                return NotFound();
            }
            var carInspection = await _context.CarInspection.FindAsync(id);
            if (carInspection == null)
            {
                return NotFound();
            }

            _context.CarInspection.Remove(carInspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarInspectionExists(int id)
        {
            return (_context.CarInspection?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
