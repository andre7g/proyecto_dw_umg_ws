using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models.Response
{
    public class Response
    {
        public int Status { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
    }
}
