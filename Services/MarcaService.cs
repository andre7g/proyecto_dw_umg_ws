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
    public class MarcaService : MarcaInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public MarcaService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateMarca(Marca _marca)
        {
            throw new NotImplementedException();
        }

        public Response GetMarcas()
        {
            throw new NotImplementedException();
        }

        public Response GetMarcasActivas(int estado_Id)
        {
            IEnumerable<Marca> list = _context.Marca.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Marcas obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowMarca(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateMarca(int id, Marca _marca)
        {
            throw new NotImplementedException();
        }
    }
}
