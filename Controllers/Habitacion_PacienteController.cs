using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Habitacion_PacienteController : ControllerBase
    {
        private readonly Habitacion_PacienteInterface _IHabitacion_Paciente;

        public Habitacion_PacienteController (Habitacion_PacienteInterface habitacion_PacienteInterface)
        {
            _IHabitacion_Paciente = habitacion_PacienteInterface;
        }


        // GET: api/values
        [HttpGet]
        [Route("GetHabitacion_PacienteByHabitacion/{habitacion_Id?}")]
        public Response GetHabitacion_PacienteByHabitacion(int habitacion_Id) => _IHabitacion_Paciente.GetHabitacion_PacienteByHabitacion(habitacion_Id);

        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IHabitacion_Paciente.ShowHabitacion_Paciente(id);

        // POST api/values
        [HttpPost]
        public Task<Response> CreateHabitacion([FromBody] Habitacion_Paciente _habitacion_Paciente) => _IHabitacion_Paciente.CreateHabitacion_Paciente(_habitacion_Paciente);

        // PUT api/values/5
        [HttpPut]
        [Route("UpdateHabitacion/{put_Id?}")]
        public Task<Response> UpdateHabitacion(int put_Id, [FromBody] Habitacion_Paciente _habitacion_Paciente) => _IHabitacion_Paciente.UpdateHabitacion_Paciente(put_Id, _habitacion_Paciente);
    }
}
