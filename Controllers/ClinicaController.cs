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
    public class ClinicaController : ControllerBase
    {
        private readonly ClinicaInterface _IClinica;

        public ClinicaController(ClinicaInterface clinicaInterface)
        {
            _IClinica = clinicaInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetClinicasActivas/{estado_Id?}")]
        public Response GetClinicasActivas(int estado_Id) => _IClinica.GetClinicasActivas(estado_Id);
    }
}
