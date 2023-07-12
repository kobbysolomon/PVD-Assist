namespace webapi
{
    public class Car
    {
        public int Id { get;set;}
        public int Year_of_manufacture { get;set;}
        public string? Vehicle_make { get;set;}
        public string? Vehicle_model { get;set;}
        public string? Vehicle_type { get; set; }
        public int Vehicle_cargo_space { get; set; }
        public int Pv { get; set; }
        public int Lv { get; set; }

        //public string? VehicleTypeId { get; set; }
        //public VehicleType? VehicleType { get; set; }
    }
}