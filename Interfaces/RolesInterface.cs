using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface RolesInterface
    {
        public Response GetRoles();

        public Response ShowRol(int Id);

        public Task<Response> CreateRol(Roles _roles);

        public Task<Response> UpdateRol(int id, Roles _roles);

        public Response GetRolesActivos(int estado_Id);
    }
}
