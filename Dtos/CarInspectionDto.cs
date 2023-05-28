namespace rent_a_car_be.Dtos
{
    public class CarInspectionDto
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public bool IsScratched { get; set; }
        public bool HasSpareWheel { get; set; }
        public bool HasGato { get; set; }
        public bool HasGlassBreaks { get; set; }
        public bool TopLeftWheel { get; set; }
        public bool TopRightWheel { get; set; }
        public bool BottomLeftWheel { get; set; }
        public bool BottomRightWheel { get; set; }
        public int FuelQuantity { get; set; }
        public DateTime InspectionDate { get; set; }
        public int EventType { get; set; }
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ClientName { get; set; }
        public string CarDescription { get; set; }
        public int? HasRent { get; set; }
    }
}
