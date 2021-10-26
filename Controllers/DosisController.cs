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
    public class DosisController : ControllerBase
    {
        private readonly DosisInterface _IDosis;

        public DosisController(DosisInterface dosisInterface)
        {
            _IDosis = dosisInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetDosisActivas/{estado_Id?}")]
        public Response GetDosisActivas(int estado_Id) => _IDosis.GetDosisActivas(estado_Id);
    }
}
