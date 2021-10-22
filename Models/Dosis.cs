using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("dosis")]
    public class Dosis
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Marca es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Estados_Id es requerido.")]
        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }
    }
}
