namespace atrapalo_api.Entities
{
    public class Robo
    {
        public long Id { get; set; }
        public Persona Persona { get; set; }
        public long PersonaId { get; set; }
        public Tipo TipoRobo { get; set; }
        public long TipoRoboId { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public long UbicacionId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
