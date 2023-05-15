using System.Reflection.Metadata;

namespace rent_a_car_be.Models
{
    public class RentAndReturn: BaseEntity
    {
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int AmountDay { get; set; }
        public int Days { get; set; }
        public string? Comment { get; set; }
        public int CarInspectionId { get; set; }
        public virtual CarInspection? CarInspection { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int CarId { get; set; }
        public virtual Car? Car { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
    }
}
