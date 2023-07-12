namespace webapi
{
    public class PackageDefault
    {
        public int Id { get; set; }
        public decimal Pkg_length { get; set; }
        public decimal Pkg_width { get; set; }
        public decimal Pkg_height { get; set; }
        public decimal Pkg_volume { get; set; }
        public string? Pkg_type { get; set; }
    }
}