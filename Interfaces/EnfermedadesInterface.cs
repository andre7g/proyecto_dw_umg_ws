using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface EnfermedadesInterface
    {
        public Response GetEnfermedades();

        public Response ShowEnfermedad(int Id);

        public Task<Response> CreateEnfermedad(Enfermedades _enfermedades);

        public Task<Response> UpdateEnfermedad(int id, Enfermedades _enfermedades);

        public Response GetEnfermedadesActivos(int estado_Id);
    }
}
