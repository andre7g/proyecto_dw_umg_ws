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
    public class HabitacionController : ControllerBase
    {
        private readonly HabitacionInterface _IHabitacion;

        public HabitacionController(HabitacionInterface habitacionInterface)
        {
            _IHabitacion = habitacionInterface;
        }

        // GET: api/
        [HttpGet]
        public Response GetHabitacion() => _IHabitacion.GetHabitacion();
        // GET: api/values
        [HttpGet]
        [Route("GetHabitacionsActivos/{estado_Id?}")]
        public Response GetHabitacionsActivos(int estado_Id) => _IHabitacion.GetHabitacionsActivos(estado_Id);

        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IHabitacion.ShowHabitacion(id);

        // POST api/values
        [HttpPost]
        public Task<Response> CreateHabitacion([FromBody] Habitacion _habitacion) => _IHabitacion.CreateHabitacion(_habitacion);

        // PUT api/values/5
        [HttpPut]
        [Route("UpdateHabitacion/{put_Id?}")]
        public Task<Response> UpdateHabitacion(int put_Id, [FromBody] Habitacion _habitacion) => _IHabitacion.UpdateHabitacion(put_Id, _habitacion);
    }
}
