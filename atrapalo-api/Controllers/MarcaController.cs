using atrapalo_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/marca")]
    public class MarcaController : Controller
    {
        private readonly AplicationDbContext _context;

        public MarcaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Marca marca)
        {
            try
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
                return Ok(marca);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var marcas = from m in _context.Marca
                             select m;
                return Ok(marcas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Marca marca)
        {
            try
            {
                if (marca.Id != null)
                {

                }
                var existe = await _context.Marca.AnyAsync(x=> x.Id == marca.Id);
                if (existe)
                {
                    _context.Update(marca);
                    await _context.SaveChangesAsync();
                    return Ok(marca);
                } else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
