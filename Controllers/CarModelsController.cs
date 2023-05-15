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
    public class CarModelsController : ControllerBase
    {
        private readonly rent_a_car_beContext _context;

        public CarModelsController(rent_a_car_beContext context)
        {
            _context = context;
        }

        // GET: api/CarModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModelDto>>> GetCarModel()
        {
            if (_context.CarModel == null)
            {
                return NotFound();
            }
            var carModelDtos = new List<CarModelDto>();
            var carModels = await _context.CarModel.Include(x => x.CarBrand).ToListAsync();
            foreach (var car in carModels)
            {
                carModelDtos.Add(new CarModelDto {
                    Description = car.Description,
                    Id = car.Id,
                    CarBrandId = car.CarBrandId,
                    Status = car.Status,
                    Marca = car?.CarBrand?.Description
                });
            }
            return carModelDtos;
        }

        // GET: api/CarModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarModel(int id)
        {
          if (_context.CarModel == null)
          {
              return NotFound();
          }
            var carModel = await _context.CarModel.FindAsync(id);

            if (carModel == null)
            {
                return NotFound();
            }

            return carModel;
        }

        // PUT: api/CarModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(int id, CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
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

        // POST: api/CarModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        {
          if (_context.CarModel == null)
          {
              return Problem("Entity set 'rent_a_car_beContext.CarModel'  is null.");
          }
            _context.CarModel.Add(carModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarModel", new { id = carModel.Id }, carModel);
        }

        // DELETE: api/CarModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarModel(int id)
        {
            if (_context.CarModel == null)
            {
                return NotFound();
            }
            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.CarModel.Remove(carModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarModelExists(int id)
        {
            return (_context.CarModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
