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
    public class Via_Administracion_ProductoController : ControllerBase
    {
        private readonly Via_Administracion_ProductoInterface _IVia_Administracion;
        public Via_Administracion_ProductoController(Via_Administracion_ProductoInterface profecionInterface)
        {
            _IVia_Administracion = profecionInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetVias_AdministracionActivas/{estado_Id?}")]
        public Response GetVias_AdministracionActivas(int estado_Id) => _IVia_Administracion.GetVias_AdministracionActivas(estado_Id);

    }
}
