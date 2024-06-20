using MediatR;
using Tienda.Servicios.Api.Libro.Aplicacion;
using FluentValidation.AspNetCore;
using Tienda.Servicios.Api.Libro.Persistencia;

namespace Tienda.Servicios.Api.Libro.Extensiones
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().
            AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

            //Aqui se cambiara a possgresql
            //services.AddDbContext<ContextoLibreria>(options =>
            //options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            //new MySqlServiceVersion(new Version(8, 0, 23))));


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });

                options.AddPolicy("AllowAll",

                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });

            });

            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            services.AddAutoMapper(typeof(Consulta.Manejador));

            return services;
        }


    }
}