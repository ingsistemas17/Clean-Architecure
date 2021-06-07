using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{
    [Table("Autor")]
    public class Autor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //[Column("Id", TypeName = "long")]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string NombreCompleto { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string CiudadProcedencia { get; set; }

        [Required]
        public string Correo { get; set; }

        public List<Libro> Libros { get; set; }


    }
}
