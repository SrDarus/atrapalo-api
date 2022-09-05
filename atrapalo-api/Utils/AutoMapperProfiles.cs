using atrapalo_api.DTO;
using atrapalo_api.Entities;
using AutoMapper;

namespace atrapalo_api.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PersonaNuevoDto, Persona>();
            CreateMap<VehiculoNuevoDto, Vehiculo>();
            CreateMap<RoboNuevoDto, Robo>();
            CreateMap<TipoNuevoDto, Tipo>();
            CreateMap<Robo, RoboDto>();
        }
    }
}
