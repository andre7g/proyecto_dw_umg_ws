using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface Via_Administracion_ProductoInterface
    {
        public Response GetVias_Administracion();

        public Response ShowVia_Administracion(int Id);

        public Task<Response> CreateVia_Administracion(Via_Administracion_Producto _via_Administracion_Producto);

        public Task<Response> UpdateVia_Administracion(int id, Via_Administracion_Producto _via_Administracion_Producto);

        public Response GetVias_AdministracionActivas(int estado_Id);
    }
}
