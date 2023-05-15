namespace rent_a_car_be.Models
{
    public class Client: BaseEntity
    {
        public Client() 
        {
            Inspections = new HashSet<CarInspection>();
            RentsAndReturns = new HashSet<RentAndReturn>();
        } 
        public string? Name { get; set; }

        public string? Identification { get; set; }

        public int CreditCard { get; set; }

        public int CreditLimit { get; set; }

        public int PersonType { get; set; }

        public ICollection<CarInspection> Inspections { get; set; }
        public ICollection<RentAndReturn> RentsAndReturns { get; set; }
    }
}
