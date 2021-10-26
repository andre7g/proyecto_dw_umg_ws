using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface MarcaInterface
    {
        public Response GetMarcas();

        public Response ShowMarca(int Id);

        public Task<Response> CreateMarca(Marca _marca);

        public Task<Response> UpdateMarca(int id, Marca _marca);

        public Response GetMarcasActivas(int estado_Id);
    }
}
