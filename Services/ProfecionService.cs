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
    public class ProfecionService : ProfecionInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public ProfecionService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateProfecion(profecion _profecion)
        {
            throw new NotImplementedException();
        }

        public Response GetProfecionActivas(int estado_Id)
        {
            IEnumerable<profecion> list = _context.profecion.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de profeciones obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetProfeciones()
        {
            throw new NotImplementedException();
        }

        public Response ShowProfecion(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateProfecion(int id, profecion _profecion)
        {
            throw new NotImplementedException();
        }
    }
}
