using AutoMapper;
using Tienda.Servicios.Api.Libro.Modelo;

namespace Tienda.Servicios.Api.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
