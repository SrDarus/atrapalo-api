using atrapalo_api.Entities;

namespace atrapalo_api.DTO
{
    public class RoboNuevoDto
    {
        public long PersonaId { get; set; }
        public long TipoRoboId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
