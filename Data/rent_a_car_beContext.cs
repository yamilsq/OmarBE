using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rent_a_car_be.Models;

namespace rent_a_car_be.Data
{
    public class rent_a_car_beContext : DbContext
    {
        public rent_a_car_beContext (DbContextOptions<rent_a_car_beContext> options)
            : base(options)
        {
        }
        public DbSet<CarFuel> CarFuel { get; set; }
        public DbSet<CarBrand> CarBrand { get; set; }
        public DbSet<CarType> CarType { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<CarInspection> CarInspection { get; set; }
        public DbSet<RentAndReturn> RentAndReturn { get; set; }
    }
}
