using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_PersonalController : ControllerBase
    {
        private readonly Tipo_PersonalInterface _ITipo_Personal;
        public Tipo_PersonalController(Tipo_PersonalInterface tipo_PersonalInterface)
        {
            _ITipo_Personal = tipo_PersonalInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetTipos_PersonalActivos/{estado_Id?}")]
        public Response GetTipos_PersonalActivos(int estado_Id) => _ITipo_Personal.GetTipos_PersonalActivos(estado_Id);
    }
}
