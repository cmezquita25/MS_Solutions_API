//#cSpell: disable

using System;
using FluentValidation;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api_PersonalGeneral.Domain.Interfaces;
using Api_PersonalGeneral.Infraestructure.Data;
using Api_PersonalGeneral.Application.Services;
using Api_PersonalGeneral.Domain.DTOS.requests;
using Api_PersonalGeneral.Infraestructure.Validators;
using Api_PersonalGeneral.Infraestructure.Repositories;


namespace Api_PersonalGeneral.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_PersonalGeneral.Api", Version = "v1" });
            });

            services.AddDbContext<PersonalGeneralContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PersonalGeneral")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<ICursoService, ServicesCurso>();
            services.AddScoped<IAlumnoService, ServiceAlumno>();
            services.AddScoped<IPorfesorService, ServiceProfesor>();
            services.AddScoped<IEstudianteService, ServiceEstudiante>();

            services.AddTransient<ImaestroInterface, MaestroSqlRepositories>();
            services.AddTransient<IalumnoInterface, AlumnoSqlRepositories>();
            services.AddTransient<IprofesorInterface, ProfesorSqlRepositories>();
            services.AddTransient<IestudianteInterface, EstudianteSqlRepositories>();
            services.AddTransient<IInscripcionesIntefaces, InscripcionSqlRepositories>();
            services.AddTransient<IadminInterface, AdminSqlRepositories>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IValidator<CursoRequests>, CursosValidator>();
            services.AddScoped<IValidator<AlumnoRequest>, AlumnoValidator>();
            services.AddScoped<IValidator<ProfesorRequest>, ProfesorValidator>();
            services.AddScoped<IValidator<InscripcionRequest>, InscritosValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_PersonalGeneral.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
