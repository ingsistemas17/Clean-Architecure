using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{
    [Table("Libro")]
    public class Libro : BaseEntity
    {


        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; }

        [Required]
        public int Anou { get; set; }

        [Required]
        public int NuPaginas { get; set; }

        [Required]
        public string Genero { get; set; }


        public long EditorialId { get; set; }
        public  Editorial Editorial { get; set; }

        public long AutorId { get; set; }
        public  Autor Autor { get; set; }


        [NotMapped]
        public string AutorNombre { get { return Autor.NombreCompleto; } }
    }
}
