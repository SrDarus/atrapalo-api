using atrapalo_api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/color")]
    public class ColorController : Controller
    {
        private readonly AplicationDbContext _context;

        public ColorController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var colores = from c in _context.Color
                              select c;
                return Ok(colores);
            }
            catch (Exception e)
            {

                return NotFound(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Color color)
        {
            _context.Add(color);
            var result = await _context.SaveChangesAsync();
            return Ok(result);
        }
    }
}
