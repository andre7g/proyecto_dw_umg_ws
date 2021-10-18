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
    public class Personal_AdministrativoController : ControllerBase
    {
        private readonly Personal_AdministrativoInterface _IPersonal_Administrativo;

        public Personal_AdministrativoController(Personal_AdministrativoInterface personal_Administrativo)
        {
            _IPersonal_Administrativo = personal_Administrativo;
        }

        // GET: api/
        [HttpGet]
        public Response GetPersonal_Administrativo() => _IPersonal_Administrativo.GetPersonal_Administrativo();
        // GET: api/values
        [HttpGet]
        [Route("GetPersonal_AdministrativoActivos/{estado_Id?}")]
        public Response GetPersonal_AdministrativoActivos(int estado_Id) => _IPersonal_Administrativo.GetPersonal_AdministrativoActivos(estado_Id);


        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IPersonal_Administrativo.ShowPersonal_Administrativo(id);


        // POST api/values
        [HttpPost]
        public Task<Response> CreatePersonal_Administrativo([FromBody] personal_administrativo _personal_Administrativo) => _IPersonal_Administrativo.CreatePersonal_Administrativo(_personal_Administrativo);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdatePersonal_Administrativo/{put_Id?}")]
        public Task<Response> UpdatePersonal_Administrativo(int put_Id, [FromBody] personal_administrativo _personal_Administrativo) => _IPersonal_Administrativo.UpdatePersonal_Administrativo(put_Id, _personal_Administrativo);
    }
}
