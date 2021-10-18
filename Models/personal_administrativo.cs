using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("personal_administrativo")]
    public class personal_administrativo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Primer_Nombre es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Primer_Nombre { get; set; }
        
        [Required(ErrorMessage = "El campo Segundo_Nombre es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Segundo_Nombre { get; set; }        
        
        [Required(ErrorMessage = "El campo Primer_Apellido es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Primer_Apellido { get; set; }

        [Required(ErrorMessage = "El campo Segundo_Apellido es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Segundo_Apellido { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido.")]
        [MaxLength(200, ErrorMessage = "El máximo de caracteres permitidos es de 200.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido.")]
        [MaxLength(15, ErrorMessage = "El máximo de caracteres permitidos es de 15.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo No_Colegiado es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string No_Colegiado { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo Fecha_Nacimiento es obligatorio")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El campo Salario es requerido.")]
        public decimal Salario { get; set; }


        [Required(ErrorMessage = "El campo Estados_Id es requerido.")]
        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }


        [Required(ErrorMessage = "El campo Profecion_Id es requerido.")]
        public int Profecion_Id { get; set; }
        [ForeignKey("Profecion_Id")]
        public virtual profecion Profecion { get; set; }


        [Required(ErrorMessage = "El campo Tipo_Personal_Id es requerido.")]
        public int Tipo_Personal_Id { get; set; }
        [ForeignKey("Tipo_Personal_Id")]
        public virtual tipo_personal Tipo_personal { get; set; }


        [Required(ErrorMessage = "El campo Cinica_Id es requerido.")]
        public int Clinica_Id { get; set; }
        [ForeignKey("Clinica_Id")]
        public virtual clinica Clinica { get; set; }


        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electronico.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo DPI es requerido.")]
        public decimal DPI { get; set; }
    }
}
