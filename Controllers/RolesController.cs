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
    public class RolesController : ControllerBase
    {
        private readonly RolesInterface _IRoles;

        public RolesController(RolesInterface rolesInterface)
        {
            _IRoles = rolesInterface;
        }

        // GET: api/
        [HttpGet]
        public Response GetRoles() => _IRoles.GetRoles();
        // GET: api/values
        [HttpGet]
        [Route("GetRolesActivos/{estado_Id?}")]
        public Response GetRolesActivos(int estado_Id) => _IRoles.GetRolesActivos(estado_Id);


        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IRoles.ShowRol(id);


        // POST api/values
        [HttpPost]
        public Task<Response> CreateRol([FromBody] Roles _roles) => _IRoles.CreateRol(_roles);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdateRol/{put_Id?}")]
        public Task<Response> UpdateRol(int put_Id, [FromBody] Roles _roles) => _IRoles.UpdateRol(put_Id, _roles);
    }
}
