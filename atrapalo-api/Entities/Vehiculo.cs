namespace atrapalo_api.Entities
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public string Modelo { get; set; }
        public Marca Marca { get; set; }
        public long MarcaId { get; set; }
        public Color Color { get; set; }
        public long ColorId { get; set; }
        public Persona Persona { get; set; }
        public long PersonaId { get; set; }


    }
}
