namespace rent_a_car_be.Models
{
    public class CarType: BaseEntity
    {
        public CarType()
        {
            Cars = new HashSet<Car>();
        }
        public string? Description { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
