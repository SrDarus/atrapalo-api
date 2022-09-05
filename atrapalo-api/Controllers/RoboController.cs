using atrapalo_api.DTO;
using atrapalo_api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/robo")]
    public class RoboController : Controller
    {

        private readonly AplicationDbContext _context;
        private readonly IMapper mapper;

        public RoboController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get(long Id)
        {
            try
            {
                var robo = await _context.Robo.FindAsync(Id);
                return Ok(robo);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(RoboNuevoDto roboDto)
        {
            try
            {
                var robo = mapper.Map<Robo>(roboDto);
                _context.Add(robo);
                var result = await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("get-robo-persona")]
        public async Task<ActionResult> ObtenerRobosPorPersona(long Id)
        {
            try
            {
                var robos = await _context.Robo
                        .Include(roboDb => roboDb.Ubicacion)
                        .Where( r => r.PersonaId.Equals(Id))
                        .Select(robo => this.mapper.Map<RoboDto>(robo))
                        .ToListAsync();
                
                if(robos.Any())
                {
                    return Ok(robos);
                } else { return NotFound(); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
