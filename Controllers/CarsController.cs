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
    public class CarsController : ControllerBase
    {
        private readonly rent_a_car_beContext _context;

        public CarsController(rent_a_car_beContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCar()
        {
          if (_context.Car == null)
          {
              return NotFound();
          }
            var carsDto = new List<CarDto>();
            var cars = await _context.Car
                                .Include(x => x.CarType)
                                .Include(x => x.CarFuel)
                                .Include(x => x.CarModel)
                                    .ThenInclude(x => x.CarBrand)
                                .ToListAsync();

            foreach (var car in cars)
            {
                carsDto.Add(new CarDto
                {
                    Id = car.Id,
                    Description = car.Description,
                    NoChasis = car.NoChasis,
                    NoMotor = car.NoMotor,
                    NoPlaca = car.NoPlaca,
                    CarTypeId = car.CarTypeId,
                    CarModelId = car.CarModelId,
                    CarFuelId = car.CarFuelId,
                    CarBrandId = car.CarModel?.CarBrandId,
                    Status = car.Status,
                    Tipo = car.CarType?.Description,
                    Marca = car?.CarModel?.CarBrand?.Description,
                    Modelo = car?.CarModel?.Description,
                    Combustible = car?.CarFuel?.Description,
                });
            }
            return carsDto;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
          if (_context.Car == null)
          {
              return Problem("Entity set 'rent_a_car_beContext.Car'  is null.");
          }
            _context.Car.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            if (_context.Car == null)
            {
                return NotFound();
            }
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return (_context.Car?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
