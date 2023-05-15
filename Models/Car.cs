namespace rent_a_car_be.Models
{
    public class Car : BaseEntity
    {
        public Car()
        {
            Inspections = new HashSet<CarInspection>();
            RentsAndReturns = new HashSet<RentAndReturn>();
        }
        public string? Description { get; set; }
        public string? NoChasis { get; set; }
        public string? NoMotor { get; set; }
        public string? NoPlaca { get; set; }
        public int CarTypeId { get; set; }
        public virtual CarType? CarType { get; set; }
        public int CarModelId { get; set; }
        public virtual CarModel? CarModel { get; set; }
        public int CarFuelId { get; set; }
        public virtual CarFuel? CarFuel { get; set; }

        public ICollection<CarInspection> Inspections { get; set; }
        public ICollection<RentAndReturn> RentsAndReturns { get; set; }
    }
}
