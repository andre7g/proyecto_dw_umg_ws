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
    public class MarcaController : ControllerBase
    {
        private readonly MarcaInterface _IMarca;

        public MarcaController(MarcaInterface marcaInterface)
        {
            _IMarca = marcaInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetMarcasActivas/{estado_Id?}")]
        public Response GetMarcasActivas(int estado_Id) => _IMarca.GetMarcasActivas(estado_Id);
    }
}
