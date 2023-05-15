namespace rent_a_car_be.Models
{
    public class Employee: BaseEntity
    {
        public Employee()
        {
            Inspections = new HashSet<CarInspection>();
            RentsAndReturns = new HashSet<RentAndReturn>();
        }
        public string? Name { get; set; }

        public string? Identification { get; set; }

        public int Shift { get; set; }

        public int CommissionPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public ICollection<CarInspection> Inspections { get; set; }
        public ICollection<RentAndReturn> RentsAndReturns { get; set; }
    }
}
