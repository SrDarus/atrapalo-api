using atrapalo_api.DTO;
using atrapalo_api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper mapper;

        public LoginController(AplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login per ) {

            try
            {
                var usuario = await _context.Persona.AnyAsync((p) => p.Correo.Equals(per.Correo) && p.Password.Equals(per.Password));

                var response = new Response()
                {
                    Status = 200,
                    Data = per,
                };
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }

        }

        [HttpPost]
        [Route("registrate")]
        [AllowAnonymous]
        public async Task<ActionResult> Post(PersonaNuevoDto perDto)
        {
            try
            {
                var per = mapper.Map<Persona>(perDto);  
                _context.Add(per);  
                var respuesta  = await _context.SaveChangesAsync();
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
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
                var existe = await _context.Persona.AnyAsync(x => x.Id == id);
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
