using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("profecion")]
    public class profecion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Profecion es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Profecion { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100.")]
        public string Descripcion { get; set; }

        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }
    }
}
