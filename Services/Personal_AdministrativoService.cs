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
    public class Personal_AdministrativoService : Personal_AdministrativoInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public Personal_AdministrativoService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreatePersonal_Administrativo(personal_administrativo _personal_Administrativo)
        {
            Response res = new Response();
            try
            {
                _context.personal_administrativo.Add(_personal_Administrativo);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _personal_Administrativo;
                _Ilogger.LogDebug("Metodo CreatePersonal_Administrativo exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreatePersonal_Administrativo: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _personal_Administrativo;
            }
            return res;
        }

        public Response GetPersonal_Administrativo()
        {
            IEnumerable<personal_administrativo> list = _context.personal_administrativo.Include(x => x.Estados).Include(x => x.Profecion).Include(x => x.Tipo_personal).Include(x => x.Clinica).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Personal obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetPersonal_AdministrativoActivos(int estado_Id)
        {
            //IEnumerable<personal_administrativo> list = _context.personal_administrativo.Where(x => x.Estados_Id == estado_Id).ToList();

            var list = (from empleados in _context.personal_administrativo
                        select new
                        {
                            empleados.Id,
                            mostrar = empleados.DPI + " - " + empleados.Primer_Nombre + " " + empleados.Segundo_Nombre + " " + empleados.Primer_Apellido + " " + empleados.Segundo_Apellido
                        }).ToList();

            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Personal obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowPersonal_Administrativo(int Id)
        {
            personal_administrativo data = _context.personal_administrativo.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Personal obtenido correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdatePersonal_Administrativo(int id, personal_administrativo _personal_Administrativo)
        {
            _personal_Administrativo.Id = id;
            Response res = new Response();
            try
            {
                _context.personal_administrativo.Update(_personal_Administrativo);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _personal_Administrativo;
                _Ilogger.LogDebug("Metodo UpdatePersonal_Administrativo exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdatePersonal_Administrativo: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _personal_Administrativo;
            }
            return res;
        }
    }
}
