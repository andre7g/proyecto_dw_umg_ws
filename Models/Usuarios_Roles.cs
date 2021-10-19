using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("Usuarios_Roles")]
    public class Usuarios_Roles
    {
        [Key]
        public int Id { get; set; }

        public int Usuarios_Id { get; set; }
        [ForeignKey("Usuarios_Id")]
        public virtual Usuarios Usuarios { get; set; }

        public int Roles_Id { get; set; }
        [ForeignKey("Roles_Id")]
        public virtual Roles Roles { get; set; }

        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }
    }
}
