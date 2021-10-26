using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface HabitacionInterface
    {
        public Response GetHabitacion();

        public Response ShowHabitacion(int Id);

        public Task<Response> CreateHabitacion(Habitacion _habitacion);

        public Task<Response> UpdateHabitacion(int id, Habitacion _habitacion);

        public Response GetHabitacionsActivos(int estado_Id);
    }
}
