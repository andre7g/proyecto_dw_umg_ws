using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface ProfecionInterface
    {
        public Response GetProfeciones();

        public Response ShowProfecion(int Id);

        public Task<Response> CreateProfecion(profecion _profecion);

        public Task<Response> UpdateProfecion(int id, profecion _profecion);

        public Response GetProfecionActivas(int estado_Id);
    }
}
