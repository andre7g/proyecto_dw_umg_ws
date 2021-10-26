using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface PresentacionInterface
    {
        public Response GetPresentaciones();

        public Response ShowPresentacion(int Id);

        public Task<Response> CreatePresentacion(Presentacion _presentacion);

        public Task<Response> UpdatePresentacion(int id, Presentacion _presentacion);

        public Response GetPresentacionesActivas(int estado_Id);
    }
}
