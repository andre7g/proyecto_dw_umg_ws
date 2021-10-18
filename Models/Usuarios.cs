using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Usuario es requerido.")]
        [MaxLength(20, ErrorMessage = "El máximo de caracteres permitidos es de 20.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo Password es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo Estados_Id es requerido.")]
        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }

        [Required(ErrorMessage = "El campo Personal_Administrativo_Id es requerido.")]
        public int Personal_Administrativo_Id { get; set; }
        [ForeignKey("Personal_Administrativo_Id")]
        public virtual personal_administrativo personal_administrativo { get; set; }
    }
}
