using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Interfaces
{
    public interface ProductosInterface
    {
        public Response GetProductos();

        public Response ShowProducto(int Id);

        public Task<Response> CreateProducto(Productos _productos);

        public Task<Response> UpdateProducto(int id, Productos _productos);

        public Response GetProductosActivos(int estado_Id);
    }
}
