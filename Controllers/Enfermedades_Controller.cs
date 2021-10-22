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
    public class Enfermedades_Controller : ControllerBase
    {
        private readonly EnfermedadesInterface _Ienfermedades;

        public Enfermedades_Controller(EnfermedadesInterface enfermedadesInterface)
        {
            _Ienfermedades = enfermedadesInterface;
        }
        // GET: api/
        [HttpGet]
        public Response GetEnfermedades() => _Ienfermedades.GetEnfermedades();
        // GET: api/values
        [HttpGet]
        [Route("GetEnfermedadesActivos/{estado_Id?}")]
        public Response GetEnfermedadesActivos(int estado_Id) => _Ienfermedades.GetEnfermedadesActivos(estado_Id);

        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _Ienfermedades.ShowEnfermedad(id);

        // POST api/values
        [HttpPost]
        public Task<Response> CreateEnfermedad([FromBody] Enfermedades _enfermedades) => _Ienfermedades.CreateEnfermedad(_enfermedades);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdateEnfermedad/{put_Id?}")]
        public Task<Response> UpdateEnfermedad(int put_Id, [FromBody] Enfermedades _enfermedades) => _Ienfermedades.UpdateEnfermedad(put_Id, _enfermedades);
    }
}
