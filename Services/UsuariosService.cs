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
    public class UsuariosService : UsuariosInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public UsuariosService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreateUsuario(Usuarios _usuarios)
        {
            Response res = new Response();
            try
            {
                _context.Usuarios.Add(_usuarios);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _usuarios;
                _Ilogger.LogDebug("Metodo CreateUsuario exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreateUsuario: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _usuarios;
            }
            return res;
        }

        public Response GetUsuarios()
        {
            IEnumerable<Usuarios> list = _context.Usuarios.Include(x => x.Estados).Include(x => x.personal_administrativo).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Usuarios obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response GetUsuariosActivas(int estado_Id)
        {
            IEnumerable<Usuarios> list = _context.Usuarios.Where(x => x.Estados_Id == estado_Id).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Usuarios obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public Response ShowUsuario(int Id)
        {
            Usuarios data = _context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();
            Response res = new Response();
            if (data != null)
            {
                res.Status = 200;
                res.Mensaje = "Usuario obtenido correctamente.";
                res.Data = data;
                return res;
            }
            res.Status = 400;
            res.Mensaje = $"No se encontro ningun registro con el id {Id}.";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdateUsuario(int id, Usuarios _usuarios)
        {
            _usuarios.Id = id;
            Response res = new Response();
            try
            {
                _context.Usuarios.Update(_usuarios);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _usuarios;
                _Ilogger.LogDebug("Metodo UpdateUsuario exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateUsuario: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _usuarios;
            }
            return res;
        }
    }
}
