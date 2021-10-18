using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface Tipo_PersonalInterface
    {
        public Response GetTipos_Personal();

        public Response ShowTipo_Personal(int Id);

        public Task<Response> CreateTipo_Personal(tipo_personal _tipo_Personal);

        public Task<Response> UpdateTipo_Personal(int id, tipo_personal _tipo_Personal);

        public Response GetTipos_PersonalActivos(int estado_Id);
    }
}
