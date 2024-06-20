using AutoMapper;
using FluentValidation;
using MediatR;
using Tienda.Servicios.Api.Libro.Modelo;
using Tienda.Servicios.Api.Libro.Persistencia;

namespace Tienda.Servicios.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public Guid? AutorLibro { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
                RuleFor(x => x.AutorLibro).NotEmpty();

            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoLibreria _contexto;

            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibro = request.AutorLibro
                };
                _contexto.LibreriasMaterial.Add(libro);
                var valor = await _contexto.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el libro");
            }
        }
    }
}
