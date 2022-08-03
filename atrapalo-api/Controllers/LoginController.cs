using atrapalo_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Response>> Post(Persona p)
        {
            try
            {
                _context.Add(p);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response>> Put(Persona persona, int id)
        {
            try
            {
                _context.Update(persona);
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


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response>> Delete(int id)
        {
            try
            {
                var response = new Response();
                var existe = await _context.Personas.AnyAsync(x => x.Id == id);
                if (existe) {
                    _context.Remove(new Persona() { Id = id });
                    var respuesta  = _context.SaveChangesAsync().Result;
                    response.Status = 200;
                    response.Messagge = "Eliminado correctamente";
                    response.Data = respuesta;
                } else { 
                    response.Status = 404;
                    response.Messagge = "Usuario no existe";
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
