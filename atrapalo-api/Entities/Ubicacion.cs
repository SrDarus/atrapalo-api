namespace atrapalo_api.Entities
{
    public class Ubicacion
    {
        public long Id { get; set; }
        public string? Pais { get; set; }
        public string? Region { get; set; }
        public string? Localidad { get; set; }
        public string? Comuna { get; set; }
        public string Direccion { get; set; }
    }
}
