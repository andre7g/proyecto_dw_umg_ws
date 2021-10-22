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
    public class PacienteController : ControllerBase
    {
        private readonly PacienteInterface _IPaciente;

        public PacienteController(PacienteInterface pacienteInterface)
        {
            _IPaciente = pacienteInterface;
        }

        // GET: api/
        [HttpGet]
        public Response GetPacientes() => _IPaciente.GetPacientes();
        // GET: api/values
        [HttpGet]
        [Route("GetPacientesActivos/{estado_Id?}")]
        public Response GetPacientesActivos(int estado_Id) => _IPaciente.GetPacientesActivos(estado_Id);


        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IPaciente.ShowPaciente(id);


        // POST api/values
        [HttpPost]
        public Task<Response> CreatePaciente([FromBody] Paciente _paciente) => _IPaciente.CreatePaciente(_paciente);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdatePaciente/{put_Id?}")]
        public Task<Response> UpdatePaciente(int put_Id, [FromBody] Paciente _paciente) => _IPaciente.UpdatePaciente(put_Id, _paciente);
    }
}
