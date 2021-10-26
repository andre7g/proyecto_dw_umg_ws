using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Services;

namespace umg_clinica_backend.Helpers
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void AddCustomServices(this IServiceCollection _services)
        {
            _services.AddTransient<Personal_AdministrativoInterface, Personal_AdministrativoService>();
            _services.AddTransient<ClinicaInterface, ClinicaService>();
            _services.AddTransient<ProfecionInterface, ProfecionService>();
            _services.AddTransient<Tipo_PersonalInterface, Tipo_PersonalService>();
            _services.AddTransient<UsuariosInterface, UsuariosService>();
            _services.AddTransient<LoginInterface, LoginService>();
            _services.AddTransient<RolesInterface, RolesService>();
            _services.AddTransient<Usuarios_RolesInterface, Usuarios_RolesService>();
            _services.AddTransient<PacienteInterface, PacienteService>();
            _services.AddTransient<ProductosInterface, ProductosService>();
            _services.AddTransient<EnfermedadesInterface, EnfermedadesService>();
            _services.AddTransient<DosisInterface, DosisService>();
            _services.AddTransient<MarcaInterface, MarcaService>();
            _services.AddTransient<PresentacionInterface, PresentacionService>();
            _services.AddTransient<Via_Administracion_ProductoInterface, Via_Administracion_ProductoService>();
            _services.AddTransient<HabitacionInterface, HabitacionService>();
            _services.AddTransient<Habitacion_PacienteInterface, Habitacion_PacienteService>();

        }
    }
}
