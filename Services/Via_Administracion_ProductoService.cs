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
    public class Via_Administracion_ProductoService : Via_Administracion_ProductoInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public Via_Administracion_ProductoService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public Task<Response> CreateVia_Administracion(Via_Administracion_Producto _via_Administracion_Producto)
        {
            throw new NotImplementedException();
        }

        public Response GetVias_Administracion()
        {
            throw new NotImplementedException();
        }

        public Response GetVias_AdministracionActivas(int estado_Id)
        {
            IEnumerable<Via_Administracion_Producto> list = _context.Via_Administracion_Producto.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Via_Administracion_Producto obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowVia_Administracion(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateVia_Administracion(int id, Via_Administracion_Producto _via_Administracion_Producto)
        {
            throw new NotImplementedException();
        }
    }
}
