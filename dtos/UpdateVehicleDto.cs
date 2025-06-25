namespace ZipZop.dtos

{
    public class UpdateVehicleDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal PricePerDay { get; set; }
        public bool Available { get; set; }
    }
}
