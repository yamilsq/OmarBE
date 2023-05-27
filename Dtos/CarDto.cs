namespace rent_a_car_be.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? NoChasis { get; set; }
        public string? NoMotor { get; set; }
        public string? NoPlaca { get; set; }
        public string? Tipo { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Combustible { get; set; }
        public int CarTypeId { get; set; }
        public int? CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public int CarFuelId { get; set; }
        public int Status { get; set; }
    }
}
