using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models.Request;

namespace umg_clinica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginInterface _ILogin;

        public LoginController(LoginInterface loginInterface)
        {
            _ILogin = loginInterface;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(AutenticarRequest _model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    var autenticarResponse = await _ILogin.Auth(_model);
                    return Ok(autenticarResponse);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error: {ex}.");
                }
            }
        }
    }
}
