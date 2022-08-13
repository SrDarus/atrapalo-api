namespace atrapalo_api.Entities
{
    public class Persona
    {
        public long Id { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

    }
}
