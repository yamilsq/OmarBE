using System.Reflection.Metadata;

namespace rent_a_car_be.Models
{
    public class CarModel: BaseEntity
    {
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }
        public string? Description { get; set; }
        public int CarBrandId { get; set; }
        public virtual CarBrand? CarBrand { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
