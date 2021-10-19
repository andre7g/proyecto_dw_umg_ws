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

        }
    }
}
