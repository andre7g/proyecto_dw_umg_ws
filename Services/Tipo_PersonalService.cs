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
    public class Tipo_PersonalService : Tipo_PersonalInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public Tipo_PersonalService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateTipo_Personal(tipo_personal _tipo_Personal)
        {
            throw new NotImplementedException();
        }

        public Response GetTipos_Personal()
        {
            throw new NotImplementedException();
        }

        public Response GetTipos_PersonalActivos(int estado_Id)
        {
            IEnumerable<tipo_personal> list = _context.tipo_personal.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de tipos de personal obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowTipo_Personal(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateTipo_Personal(int id, tipo_personal _tipo_Personal)
        {
            throw new NotImplementedException();
        }
    }
}
