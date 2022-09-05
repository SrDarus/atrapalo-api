using atrapalo_api.DTO;
using atrapalo_api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace atrapalo_api.Controllers
{
    [ApiController]
    [Route("api/vehiculo")]
    public class VehiculoController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper mapper;

        public VehiculoController(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VehiculoNuevoDto vehDto)
        {
            try
            {


                var veh = mapper.Map<Vehiculo>(vehDto);
                //var veh = new Vehiculo()
                //{
                //    Modelo = vehDto.Modelo,
                //    MarcaId = vehDto.MarcaId,
                //    ColorId = vehDto.ColorId,
                //    PersonaId = vehDto.PersonaId
                //};
                _context.Add(veh);
                var res = await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
