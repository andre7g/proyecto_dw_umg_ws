using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("habitacion")]
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Numero es requerido.")]

        public int Numero { get; set; }

        [Required(ErrorMessage = "El campo Area_Id es requerido.")]
        public int Area_Id { get; set; }
        [ForeignKey("Area_Id")]
        public virtual Area Area { get; set; }

        [Required(ErrorMessage = "El campo Clinica_Id es requerido.")]
        public int  Cinica_Id { get; set; }
        [ForeignKey("Cinica_Id")]
        public virtual clinica Clinica { get; set; }

        [Required(ErrorMessage = "El campo Estados_Id es requerido.")]
        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }
    }
}
