using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface DosisInterface
    {
        public Response GetDosis();

        public Response ShowDosis(int Id);

        public Task<Response> CreateDosis(Dosis _dosis);

        public Task<Response> UpdateDosis(int id, Dosis _dosis);

        public Response GetDosisActivas(int estado_Id);
    }
}
