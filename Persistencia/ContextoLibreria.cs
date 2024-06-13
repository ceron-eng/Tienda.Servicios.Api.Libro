using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.Libro.Modelo;

namespace Tienda.Servicios.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { 
        }

        public DbSet<LibreriaMaterial> LibreriasMaterial { get; set; }
    }
}
