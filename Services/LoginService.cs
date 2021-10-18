using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Data;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models.Request;
using umg_clinica_backend.Models.Common;
using Microsoft.Extensions.Options;
using umg_clinica_backend.Models.Response;
using Microsoft.EntityFrameworkCore;
using umg_clinica_backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace umg_clinica_backend.Services
{
    public class LoginService : LoginInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public LoginService(IOptions<AppSettings> appSettings, ApplicationDbContext Context)
        {
            _appSettings = appSettings.Value;
            _context = Context;
        }
        public async Task<Response> Auth(AutenticarRequest model)
        {
            AutenticarResponse response = new AutenticarResponse();
            Response res = new Response();
            try
            {
                var usuario = await _context.Usuarios.Where(x => x.Usuario == model.User && x.Password == model.Pass).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    response.Id = usuario.Id;
                    response.Usuario = usuario.Usuario;
                    response.Token = GetToken(usuario);

                    res.Status = 200;
                    res.Mensaje = "Autenticado correctamente.";
                    res.Data = response;
                    return res;
                }
                res.Status = 400;
                res.Mensaje = "Correo  y Contraseña incorrectos.";
                res.Data = null;
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetToken(Usuarios usuarios)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,usuarios.Id.ToString()),
                        new Claim(ClaimTypes.Name,usuarios.Usuario.ToString())
                    }

                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
