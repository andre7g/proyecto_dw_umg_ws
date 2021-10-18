using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models.Response
{
    public class AutenticarResponse
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
    }
}
