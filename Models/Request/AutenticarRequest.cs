using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models.Request
{
    public class AutenticarRequest
    {
        [Required]
        public string User { get; set; }
        public string Pass { get; set; }
    }
}
