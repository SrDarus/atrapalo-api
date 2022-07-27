using atrapalo_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly AplicationDbContext _context;
        public LoginController(AplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public Response Get() {
            
            var persona = new Persona()
            {
                Rut = 16268294,
                Dv = "6",
                Nombres = "Claudio Ivan",
                Apellidos = "Vargas Lillo",
                Correo = "claudiovargaslillo@gmail.com"

            };
            var response = new Response()
            {
                Status = 200,
                Data = persona,
            };
            return response; 
        
        }

        [HttpPost]
        [Route("registrate")]
        public async Task<ActionResult<Response>>  Post( Persona p)
        {
            try
            {
                _context.Add(p);
                await _context.SaveChangesAsync();
                var response = new Response()
                {
                    Status = 200,
                    Messagge = "Creado correctamente",
                };
                return response;

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
