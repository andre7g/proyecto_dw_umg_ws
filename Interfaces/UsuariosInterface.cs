using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface UsuariosInterface
    {
        public Response GetUsuarios();

        public Response ShowUsuario(int Id);

        public Task<Response> CreateUsuario(Usuarios _usuarios);

        public Task<Response> UpdateUsuario(int id, Usuarios _usuarios);

        public Response GetUsuariosActivas(int estado_Id);
    }
}
