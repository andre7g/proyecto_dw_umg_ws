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
    public class PresentacionController : ControllerBase
    {
        private readonly PresentacionInterface _IPresentacion;

        public PresentacionController(PresentacionInterface presentacionInterface)
        {
            _IPresentacion = presentacionInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetPresentacionesActivas/{estado_Id?}")]
        public Response GetPresentacionesActivas(int estado_Id) => _IPresentacion.GetPresentacionesActivas(estado_Id);
    }
}
