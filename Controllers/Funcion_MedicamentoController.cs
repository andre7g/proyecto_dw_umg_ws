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
    public class Funcion_MedicamentoController : ControllerBase
    {
        private readonly Funcion_MedicamentoInterface _IFuncion_Medicamento;

        public Funcion_MedicamentoController(Funcion_MedicamentoInterface funcion_Medicamento)
        {
            _IFuncion_Medicamento = funcion_Medicamento;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetFunciones_MedicamentoActivas/{estado_Id?}")]
        public Response GetFunciones_MedicamentoActivas(int estado_Id) => _IFuncion_Medicamento.GeFunciones_MedicamentoActivas(estado_Id);
    }
}
