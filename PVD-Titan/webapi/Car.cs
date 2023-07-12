namespace webapi
{
    public class Car
    {
        public int Id { get;set;}
        public int Year { get;set;}
        public string? Make { get;set;}
        public string? Model { get;set;}
        public string? Type { get; set; }
        public int Cargo_volume { get; set; }
        public int Pv { get; set; }
        public int Lv { get; set; }

        public string? VehicleTypeId { get; set; }
        public VehicleType? VehicleType { get; set; }
    }
}