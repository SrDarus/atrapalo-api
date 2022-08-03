using atrapalo_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/vehiculo")]
    public class VehiculoController : Controller
    {
        private readonly AplicationDbContext _context;

        public VehiculoController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vehiculo vehiculo)
        {
            try
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
