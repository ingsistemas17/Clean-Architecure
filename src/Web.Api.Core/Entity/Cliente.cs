using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{

    [Table("TEST_CLIENTE")]
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("IdCliente", TypeName = "numeric(18,0)")]
        public decimal IdCliente { get; set; }

        [Required]
        [Column("Identifiacion", TypeName = "numeric(18,0)")]
        public decimal Identifiacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(300)]
        public string Direccion { get; set; }


        [MaxLength(50)]
        public string Telefono { get; set; }


        [MaxLength(100)]
        public string Email { get; set; }





    }
}
