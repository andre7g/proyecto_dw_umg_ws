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
    public class PacienteService : PacienteInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public PacienteService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreatePaciente(Paciente _paciente)
        {
            Response res = new Response();
            try
            {
                _context.Paciente.Add(_paciente);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _paciente;
                _Ilogger.LogDebug("Metodo CreatePersonal_Administrativo exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreatePaciente: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _paciente;
            }
            return res;
        }

        public Response GetPacientes()
        {
            IEnumerable<Paciente> list = _context.Paciente.Include(x => x.Estados).Include(x => x.Profecion).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Pacientes obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetPacientesActivos(int estado_Id)
        {
            var list = (from pacientes in _context.Paciente
                        select new
                        {
                            pacientes.Id,
                            mostrar = pacientes.DPI + " - " + pacientes.Primer_Nombre + " " + pacientes.Segundo_Nombre + " " + pacientes.Primer_Apellido + " " + pacientes.Segundo_Apellido
                        }).ToList();

            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Pacinetes obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowPaciente(int Id)
        {
            Paciente data = _context.Paciente.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Paciente obtenido correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdatePaciente(int id, Paciente _paciente)
        {
            _paciente.Id = id;
            Response res = new Response();
            try
            {
                _context.Paciente.Update(_paciente);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _paciente;
                _Ilogger.LogDebug("Metodo UpdatePaciente exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdatePersonal_Administrativo: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _paciente;
            }
            return res;
        }
    }
}
