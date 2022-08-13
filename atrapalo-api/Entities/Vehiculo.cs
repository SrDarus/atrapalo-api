namespace atrapalo_api.Entities
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public Marca Marca { get; set; }
        public long IdMarca { get; set; }
        public string Modelo { get; set; }
        public Color Color { get; set; }
        public long IdColor { get; set; }
        public long PersonaId { get; set; }

    }
}
