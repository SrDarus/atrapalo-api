using atrapalo_api.DTO;
using atrapalo_api.Entities;
using atrapalo_api.Utils.Enumerables;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/tipo")]
    public class TipoController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper mapper;

        public TipoController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var tipoRoboList = await _context.Tipo
                    .ToListAsync();
                if (tipoRoboList.Any())
                {
                    return Ok(tipoRoboList);
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return NotFound(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoNuevoDto tipoDto)
        {
            var tipo = mapper.Map<Tipo>(tipoDto);
            _context.Add(tipo);
            var resultado = await _context.SaveChangesAsync();
            if(resultado == 1)
            {
                return Ok(resultado);
            }
            return NotFound(resultado);
        }
    }
}
