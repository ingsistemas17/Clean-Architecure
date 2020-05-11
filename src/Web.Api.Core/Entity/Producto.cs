using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{

    [Table("TEST_PRODUCTO")]
    public class Producto
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("IdProducto", TypeName = "numeric(18,0)")]
        public decimal IdProducto { get; set; }

        [Required]
        [MaxLength(30)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }



        [Required]
        [Column("ValorUnidad", TypeName = "numeric(18,3)")]
        public decimal ValorUnidad { get; set; }


        [Required]
        public int Stock { get; set; }

    }
}
