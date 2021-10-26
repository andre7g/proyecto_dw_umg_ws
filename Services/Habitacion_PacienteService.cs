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
    public class Habitacion_PacienteService : Habitacion_PacienteInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public Habitacion_PacienteService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreateHabitacion_Paciente(Habitacion_Paciente _habitacion_Paciente)
        {
            Habitacion data = _context.Habitacion.Where(x => x.Id == _habitacion_Paciente.Habitacion_Id).FirstOrDefault();

            Response reshabitacion = new Response();
            reshabitacion = await UpdateHabitacion(data);
            Response res = new Response();
            if (reshabitacion.Status == 200)
            {
                try
                {
                    _context.Habitacion_Paciente.Add(_habitacion_Paciente);
                    await _context.SaveChangesAsync();

                    res.Status = 200;
                    res.Mensaje = "Guardado con Exito.";
                    res.Data = _habitacion_Paciente;
                    _Ilogger.LogDebug("Metodo CreateHabitacion exitoso.");
                }
                catch (Exception ex)
                {
                    _Ilogger.LogError("Error en metodo CreateHabitacion: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                    _Ilogger.LogDebug("----------- Fin transaccion ----------");
                    res.Mensaje = "Error: " + ex;
                    res.Status = 500;
                    res.Data = _habitacion_Paciente;
                }

            }
            return res;
        }

        public Response GetHabitacion_PacienteByHabitacion(int habitacion_Id)
        {
            IEnumerable<Habitacion_Paciente> list = _context.Habitacion_Paciente.Where(x => x.Estados_Id == 1 && x.Habitacion_Id == habitacion_Id).Include(x => x.Habitacion).Include(x => x.Paciente).Include(x => x.Estados).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Habitacion_Paciente obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowHabitacion_Paciente(int Id)
        {
            Habitacion_Paciente data = _context.Habitacion_Paciente.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Habitacion_Paciente obtenida correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdateHabitacion_Paciente(int id, Habitacion_Paciente _habitacion_Paciente)
        {
            _habitacion_Paciente.Id = id;
            Response res = new Response();
            try
            {
                _context.Habitacion_Paciente.Update(_habitacion_Paciente);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _habitacion_Paciente;
                _Ilogger.LogDebug("Metodo UpdateHabitacion_Paciente exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateHabitacion_Paciente: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _habitacion_Paciente;
            }
            return res;
        }

        public async Task<Response> UpdateHabitacion(Habitacion _habitacion)
        {
            _habitacion.Estados_Id = 4;
            Response res = new Response();
            try
            {
                _context.Habitacion.Update(_habitacion);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _habitacion;
                _Ilogger.LogDebug("Metodo UpdateHabitacion exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateHabitacion: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _habitacion;
            }
            return res;
        }
    }
}
