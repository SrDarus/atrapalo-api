namespace atrapalo_api.Entities
{
    public class Vehiculo
    {
        public long Id { get; set; }
        public Marca Marca { get; set; }
        public string Modelo { get; set; }
        public string ColorId { get; set; }
        public long PersonaId { get; set; }
        public Persona Persona { get; set; }

    }
}
