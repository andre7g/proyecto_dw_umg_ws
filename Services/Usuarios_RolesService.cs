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
    public class Usuarios_RolesService : Usuarios_RolesInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ILoggerManager _Ilogger;
        public Usuarios_RolesService(ApplicationDbContext Context, ILoggerManager Ilogger)
        {
            _context = Context;
            _Ilogger = Ilogger;
        }
        public async Task<Response> CreateUsuarios_Roles(Usuarios_Roles _usuarios_Roles)
        {
            Response res = new Response();
            try
            {
                _context.Usuarios_Roles.Add(_usuarios_Roles);
                await _context.SaveChangesAsync();

                res.Status = 200;
                res.Mensaje = "Guardado con Exito.";
                res.Data = _usuarios_Roles;
                _Ilogger.LogDebug("Metodo CreateUsuarios_Roles exitoso.");
            }
            catch (Exception ex)
            {
                _Ilogger.LogError("Error en metodo CreateUsuarios_Roles: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _usuarios_Roles;
            }
            return res;
        }

        public Response GetUsuariosRolByUsuario(int usuario_Id)
        {
            IEnumerable<Usuarios_Roles> list = _context.Usuarios_Roles.Where(x => x.Estados_Id == 1 && x.Usuarios_Id == usuario_Id).Include(x => x.Roles).ToList();
            Response res = new Response();
            if (list.Count() != 0)
            {
                res.Status = 200;
                res.Mensaje = "Lista de Usuarios_Roles obtenida correctamente.";
                res.Data = list;
                return res;
            }
            res.Status = 400;
            res.Mensaje = "No se encontraron registros";
            res.Data = null;
            return res;
        }

        public async Task<Response> UpdateUsuarios_Roles(int id, Usuarios_Roles _usuarios_Roles)
        {
            _usuarios_Roles.Id = id;
            Response res = new Response();
            try
            {
                _context.Usuarios_Roles.Update(_usuarios_Roles);
                await _context.SaveChangesAsync();
                res.Mensaje = "Modificado con exito.";
                res.Status = 200;
                res.Data = _usuarios_Roles;
                _Ilogger.LogDebug("Metodo UpdateUsuario exitoso.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _Ilogger.LogError("Error en metodo UpdateUsuario: " + ex.Message + ".--" + ex.InnerException + ".--" + ex.Source);
                _Ilogger.LogDebug("----------- Fin transaccion ----------");
                res.Mensaje = "Error: " + ex;
                res.Status = 500;
                res.Data = _usuarios_Roles;
            }
            return res;
        }
    }
}
