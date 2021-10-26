using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface Habitacion_PacienteInterface
    {

        public Response ShowHabitacion_Paciente(int Id);

        public Task<Response> CreateHabitacion_Paciente(Habitacion_Paciente _habitacion_Paciente);

        public Task<Response> UpdateHabitacion_Paciente(int id, Habitacion_Paciente _habitacion_Paciente);

        public Response GetHabitacion_PacienteByHabitacion(int habitacion_Id);
    }
}
