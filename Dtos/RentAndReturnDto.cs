namespace rent_a_car_be.Dtos
{
    public class RentAndReturnDto
    {
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int AmountDay { get; set; }
        public int Days { get; set; }
        public string? Comment { get; set; }
        public string? CarDescription { get; set; }
        public string? ClientName { get; set; }
        public string? EmployeeName { get; set; }
        public int CarInspectionId { get; set; }
        public int Id { get; set; }
        public int Status { get; set; }
        public int EmployeeId { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }

    }
}
