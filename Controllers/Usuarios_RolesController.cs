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
    public class Usuarios_RolesController : ControllerBase
    {
        private readonly Usuarios_RolesInterface _IUsuarios_Roles;

        public Usuarios_RolesController(Usuarios_RolesInterface usuarios_Roles)
        {
            _IUsuarios_Roles = usuarios_Roles;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetUsuariosRolByUsuario/{usuario_Id?}")]
        public Response GetUsuariosRolByUsuario(int usuario_Id) => _IUsuarios_Roles.GetUsuariosRolByUsuario(usuario_Id);


        // POST api/values
        [HttpPost]
        public Task<Response> CreateUsuarios_Roles([FromBody] Usuarios_Roles usuarios_Roles) => _IUsuarios_Roles.CreateUsuarios_Roles(usuarios_Roles);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdateUsuarios_Roles/{put_Id?}")]
        public Task<Response> UpdateUsuarios_Roles(int put_Id, Usuarios_Roles usuarios_Roles) => _IUsuarios_Roles.UpdateUsuarios_Roles(put_Id, usuarios_Roles);
    }
}
