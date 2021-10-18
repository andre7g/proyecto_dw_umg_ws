using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("Estados")]
    public class Estados
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Estado es requerido.")]
        [MaxLength(20, ErrorMessage = "El máximo de caracteres permitidos es de 20.")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo de caracteres permitidos es de 100.")]
        public string Descripcion { get; set; }
    }
}
