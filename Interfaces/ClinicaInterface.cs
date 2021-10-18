using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface ClinicaInterface
    {
        public Response GetClinicas();

        public Response ShowClinica(int Id);

        public Task<Response> CreateClinica(clinica _clinica);

        public Task<Response> UpdateClinica(int id, clinica _clinica);

        public Response GetClinicasActivas(int estado_Id);
    }
}
