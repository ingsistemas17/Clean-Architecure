using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{
    [Table("Editorial")]
    public class Editorial
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //[Column("Id", TypeName = "long")]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [Required]
        public string DireccionCorrespondencia { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public int MaxLibros { get; set; }

    }
}
