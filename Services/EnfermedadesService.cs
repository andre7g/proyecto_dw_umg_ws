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
    public class EnfermedadesService : EnfermedadesInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public EnfermedadesService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreateEnfermedad(Enfermedades _enfermedades)
        {
            Response res = new Response();
            try
            {
                _context.Enfermedades.Add(_enfermedades);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _enfermedades;
                _Ilogger.LogDebug("Metodo CreateEnfermedad exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreateEnfermedad: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _enfermedades;
            }
            return res;
        }

        public Response GetEnfermedades()
        {
            IEnumerable<Enfermedades> list = _context.Enfermedades.Include(x => x.Estados).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Enfermedades obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetEnfermedadesActivos(int estado_Id)
        {
            IEnumerable<Enfermedades> list = _context.Enfermedades.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Enfermedades obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowEnfermedad(int Id)
        {
            Enfermedades data = _context.Enfermedades.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Enfermedad obtenido correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdateEnfermedad(int id, Enfermedades _enfermedades)
        {
            _enfermedades.Id = id;
            Response res = new Response();
            try
            {
                _context.Enfermedades.Update(_enfermedades);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _enfermedades;
                _Ilogger.LogDebug("Metodo UpdateEnfermedad exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateEnfermedad: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _enfermedades;
            }
            return res;
        }
    }
}
