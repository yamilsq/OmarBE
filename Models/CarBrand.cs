using Microsoft.Extensions.Hosting;

namespace rent_a_car_be.Models
{
    public class CarBrand: BaseEntity
    {
        public CarBrand()
        {
            Models = new HashSet<CarModel>();
        }
        public string? Description { get; set; }
        public ICollection<CarModel> Models { get; set; }
    }
}
