using Microsoft.EntityFrameworkCore;
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
    public class ProductosService : ProductosInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public ProductosService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreateProducto(Productos _productos)
        {
            Response res = new Response();
            try
            {
                _context.Productos.Add(_productos);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _productos;
                _Ilogger.LogDebug("Metodo CreateProducto exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreateProducto: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _productos;
            }
            return res;
        }

        public Response GetProductos()
        {
            IEnumerable<Productos> list = _context.Productos.Include(x => x.Via_Administracion_Producto).Include(x => x.Marca).Include(x => x.Dosis).Include(x => x.Presentacion).Include(x => x.Estados).Include(x => x.Funcion_medicamento).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Productos obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetProductosActivos(int estado_Id)
        {
            IEnumerable<Productos> list = _context.Productos.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Productos obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetProductosActivosByFuncion(int funcion_Id)
        {
            IEnumerable<Productos> list = _context.Productos.Where(x => x.Estados_Id == 1 && x.funcion_medicamento_Id == funcion_Id).Include(x => x.Via_Administracion_Producto).Include(x => x.Marca).Include(x => x.Dosis).Include(x => x.Presentacion).Include(x => x.Estados).Include(x => x.Funcion_medicamento).ToList();

            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Productos obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowProducto(int Id)
        {
            Productos data = _context.Productos.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Producto obtenido correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdateProducto(int id, Productos _productos)
        {
            _productos.Id = id;
            Response res = new Response();
            try
            {
                _context.Productos.Update(_productos);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _productos;
                _Ilogger.LogDebug("Metodo UpdateProducto exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateProducto: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _productos;
            }
            return res;
        }
    }
}
