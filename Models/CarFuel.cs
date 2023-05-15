namespace rent_a_car_be.Models
{
    public class CarFuel: BaseEntity
    {
        public CarFuel()
        {
            Cars = new HashSet<Car>();
        }

        public string? Description { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
