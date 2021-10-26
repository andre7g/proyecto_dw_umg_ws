using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("habitacion_paciente")]
    public class Habitacion_Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Habitacion_Id es requerido.")]
        public int Habitacion_Id { get; set; }
        [ForeignKey("Habitacion_Id")]
        public virtual Habitacion Habitacion { get; set; }

        [Required(ErrorMessage = "El campo Paciente_Id es requerido.")]
        public int Paciente_Id { get; set; }
        [ForeignKey("Paciente_Id")]
        public virtual Paciente Paciente { get; set; }

        [Required(ErrorMessage = "El campo Estados_Id es requerido.")]
        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }

    }
}
