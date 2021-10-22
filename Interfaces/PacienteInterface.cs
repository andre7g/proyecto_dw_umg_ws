using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface PacienteInterface
    {
        public Response GetPacientes();

        public Response ShowPaciente(int Id);

        public Task<Response> CreatePaciente(Paciente _paciente);

        public Task<Response> UpdatePaciente(int id, Paciente _paciente);

        public Response GetPacientesActivos(int estado_Id);
    }
}
