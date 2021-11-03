using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Data;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Services
{
    public class Funcion_MedicamentoService : Funcion_MedicamentoInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public Funcion_MedicamentoService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateFuncion_Medicamento(Funcion_medicamento _funcion_Medicamento)
        {
            throw new NotImplementedException();
        }

        public Response GeFunciones_MedicamentoActivas(int estado_Id)
        {
            IEnumerable<Funcion_medicamento> list = _context.Funcion_medicamento.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Funcion_medicamento obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetFuncione_Medicamento()
        {
            throw new NotImplementedException();
        }

        public Response ShowFuncion_Medicamento(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateFuncion_Medicamento(int id, Funcion_medicamento _funcion_Medicamento)
        {
            throw new NotImplementedException();
        }
    }
}
