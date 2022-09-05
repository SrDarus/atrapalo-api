using atrapalo_api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/persona")]
    public class PersonaController : Controller
    {
        private readonly AplicationDbContext _context;

        public PersonaController(AplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Persona persona)
            {
            try
            {
                //var response = new Response();
                
                _context.Add(persona);
                var response = await _context.SaveChangesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var response = new Response();
                var persona = await _context.Persona.FindAsync(id);

                if (persona == null) { return NotFound(); }
                else
                {
                    response.Status = 200;
                    response.Data = persona;
                }
                return Ok(response);

            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }

        }
    }
}
