using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using umg_clinica_backend.Interfaces;
using umg_clinica_backend.Models;
using umg_clinica_backend.Models.Response;

namespace umg_clinica_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosInterface _IProductos;
        public ProductosController(ProductosInterface productosInterface)
        {
            _IProductos = productosInterface;
        }

        // GET: api/
        [HttpGet]
        public Response GetProductos() => _IProductos.GetProductos();
        // GET: api/values
        [HttpGet]
        [Route("GetProductosActivos/{estado_Id?}")]
        public Response GetProductosActivos(int estado_Id) => _IProductos.GetProductosActivos(estado_Id);

        // GET api/values/5
        [HttpGet("{id}")]
        public Response GetById(int id) => _IProductos.ShowProducto(id);


        // POST api/values
        [HttpPost]
        public Task<Response> CreateProducto([FromBody] Productos _productos) => _IProductos.CreateProducto(_productos);


        // PUT api/values/5
        [HttpPut]
        [Route("UpdateProducto/{put_Id?}")]
        public Task<Response> UpdateProducto(int put_Id, [FromBody] Productos _productos) => _IProductos.UpdateProducto(put_Id, _productos);
    }
}
