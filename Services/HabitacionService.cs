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
    public class HabitacionService : HabitacionInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public HabitacionService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreateHabitacion(Habitacion _habitacion)
        {
            Response res = new Response();
            try
            {
                _context.Habitacion.Add(_habitacion);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _habitacion;
                _Ilogger.LogDebug("Metodo CreateHabitacion exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreateHabitacion: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _habitacion;
            }
            return res;
        }

        public Response GetHabitacion()
        {
            IEnumerable<Habitacion> list = _context.Habitacion.Include(x => x.Area).Include(x => x.Clinica).Include(x => x.Estados).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Habitaciones obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetHabitacionsActivos(int estado_Id)
        {
            IEnumerable<Habitacion> list = _context.Habitacion.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Habitacion obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowHabitacion(int Id)
        {
            Habitacion data = _context.Habitacion.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Habitacion obtenida correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdateHabitacion(int id, Habitacion _habitacion)
        {
            _habitacion.Id = id;
            Response res = new Response();
            try
            {
                _context.Habitacion.Update(_habitacion);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _habitacion;
                _Ilogger.LogDebug("Metodo UpdateRol exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateRol: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _habitacion;
            }
            return res;
        }
    }
}
