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
    public class PresentacionService : PresentacionInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public PresentacionService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreatePresentacion(Presentacion _presentacion)
        {
            throw new NotImplementedException();
        }

        public Response GetPresentaciones()
        {
            throw new NotImplementedException();
        }

        public Response GetPresentacionesActivas(int estado_Id)
        {
            IEnumerable<Presentacion> list = _context.Presentacion.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Presentacion obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowPresentacion(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdatePresentacion(int id, Presentacion _presentacion)
        {
            throw new NotImplementedException();
        }
    }
}
