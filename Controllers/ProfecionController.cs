using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfecionController : ControllerBase
    {
        private readonly ProfecionInterface _IProfecion;

        public ProfecionController(ProfecionInterface profecionInterface)
        {
            _IProfecion = profecionInterface;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetProfecionActivas/{estado_Id?}")]
        public Response GetProfecionActivas(int estado_Id) => _IProfecion.GetProfecionActivas(estado_Id);
    }
}
