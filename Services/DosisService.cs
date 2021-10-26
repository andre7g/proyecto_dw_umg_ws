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
    public class DosisService : DosisInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public DosisService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateDosis(Dosis _dosis)
        {
            throw new NotImplementedException();
        }

        public Response GetDosis()
        {
            throw new NotImplementedException();
        }

        public Response GetDosisActivas(int estado_Id)
        {
            IEnumerable<Dosis> list = _context.Dosis.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Dosis obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowDosis(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateDosis(int id, Dosis _dosis)
        {
            throw new NotImplementedException();
        }
    }
}
