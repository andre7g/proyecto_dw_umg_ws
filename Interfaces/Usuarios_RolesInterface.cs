using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface Usuarios_RolesInterface
    {
        public Task<Response> CreateUsuarios_Roles(Usuarios_Roles _usuarios_Roles);

        public Task<Response> UpdateUsuarios_Roles(int id, Usuarios_Roles _usuarios_Roles);

        public Response GetUsuariosRolByUsuario(int usuario_Id);
    }
}
