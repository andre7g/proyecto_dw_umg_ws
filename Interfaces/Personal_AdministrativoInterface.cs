using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface Personal_AdministrativoInterface
    {
        public Response GetPersonal_Administrativo();

        public Response ShowPersonal_Administrativo(int Id);

        public Task<Response> CreatePersonal_Administrativo(personal_administrativo _personal_Administrativo);

        public Task<Response> UpdatePersonal_Administrativo(int id, personal_administrativo _personal_Administrativo);

        public Response GetPersonal_AdministrativoActivos(int estado_Id);
    }
}
