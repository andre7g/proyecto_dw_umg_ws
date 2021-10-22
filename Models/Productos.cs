using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umg_clinica_backend.Models
{
    [Table("productos")]
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es requerido.")]
        [MaxLength(45, ErrorMessage = "El máximo de caracteres permitidos es de 45.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Estados_Id es requerido.")]
        public int Estados_Id { get; set; }
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }

        [Required(ErrorMessage = "El campo Via_Administracion_Producto_Id es requerido.")]
        public int Via_Administracion_Producto_Id { get; set; }
        [ForeignKey("Via_Administracion_Producto_Id")]
        public virtual Via_Administracion_Producto Via_Administracion_Producto { get; set; }

        [Required(ErrorMessage = "El campo Marca_Id es requerido.")]
        public int Marca_Id { get; set; }
        [ForeignKey("Marca_Id")]
        public virtual Marca Marca { get; set; }

        [Required(ErrorMessage = "El campo Dosis_Id es requerido.")]
        public int Dosis_Id { get; set; }
        [ForeignKey("Dosis_Id")]
        public virtual Dosis Dosis { get; set; }        
        
        [Required(ErrorMessage = "El campo Presentacion_Id es requerido.")]
        public int Presentacion_Id { get; set; }
        [ForeignKey("Presentacion_Id")]
        public virtual Presentacion Presentacion { get; set; }
    }
}
