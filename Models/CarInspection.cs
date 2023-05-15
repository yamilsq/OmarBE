namespace rent_a_car_be.Models
{
    public class CarInspection : BaseEntity
    {
        public CarInspection()
        {
            RentsAndReturns = new HashSet<RentAndReturn>();
        }
        public bool IsScratched { get; set; }

        public bool HasSpareWheel { get; set; }
        public bool HasGato { get; set; }
        public bool HasGlassBreaks { get; set; }
        public bool TopLeftWheel { get; set; }
        public bool TopRightWheel { get; set; }
        public bool BottomLeftWheel { get; set; }
        public bool BottomRightWheel { get; set; }

        public DateTime InspectionDate { get; set; }

        public int EventType { get; set; }

        public int CarId { get; set; }
        public virtual Car? Car { get; set; }

        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

        public ICollection<RentAndReturn> RentsAndReturns { get; set; }

    }
}
       