using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("clinica")]
    public class clinica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido.")]
        [MaxLength(300, ErrorMessage = "El máximo de caracteres permitidos es de 300.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido.")]
        [MaxLength(15, ErrorMessage = "El máximo de caracteres permitidos es de 15.")]
        public string Telefono { get; set; }

        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }
    }
}
