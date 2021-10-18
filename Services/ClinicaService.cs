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
    public class ClinicaService : ClinicaInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public ClinicaService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateClinica(clinica _clinica)
        {
            throw new NotImplementedException();
        }

        public Response GetClinicas()
        {
            throw new NotImplementedException();
        }

        public Response GetClinicasActivas(int estado_Id)
        {
            IEnumerable<clinica> list = _context.clinica.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de clinicas obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowClinica(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateClinica(int id, clinica _clinica)
        {
            throw new NotImplementedException();
        }
    }
}
