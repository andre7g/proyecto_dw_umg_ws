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
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosInterface _IUsuarios;

        public UsuariosController(UsuariosInterface usuariosInterface)
        {
            _IUsuarios = usuariosInterface;
        }

        // GET: api/
        [HttpGet]
        public Response GetUsuarios() => _IUsuarios.GetUsuarios();
        // GET: api/values
        [HttpGet]
        [Route("GetUsuariosActivos/{estado_Id?}")]
        public Response GetUsuariosActivos(int estado_Id) => _IUsuarios.GetUsuariosActivas(estado_Id);


        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IUsuarios.ShowUsuario(id);


        // POST api/values
        [HttpPost]
        public Task<Response> CreateUsuario([FromBody] Usuarios _usuarios) => _IUsuarios.CreateUsuario(_usuarios);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdateUsuario/{put_Id?}")]
        public Task<Response> UpdateUsuario(int put_Id, [FromBody] Usuarios _usuarios) => _IUsuarios.UpdateUsuario(put_Id, _usuarios);
    }
}
