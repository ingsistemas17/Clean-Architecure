using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{

    [Table("TEST_FACTURA_DETALLE")]
    public class FacturaDetalle
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("IdFacturaDetalle", TypeName = "numeric(18,0)")]
        public decimal IdFacturaDetalle { get; set; }


        [ForeignKey("IdFactura")]
        public Factura FacturaEntity { get; set; }
        [Required]
        [Column("IdFactura", TypeName = "numeric(18,0)")]
        public decimal IdFactura { get; set; }

        [ForeignKey("IdProducto")]
        public Producto ProductoEntity { get; set; }
        [Required]
        [Column("IdProducto", TypeName = "numeric(18,0)")]
        public decimal IdProducto { get; set; }


        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column("ValorUnidad", TypeName = "numeric(18,3)")]
        public decimal ValorUnidad { get; set; }


        [Required]
        [Column("ValorTotal", TypeName = "numeric(18,3)")]
        public decimal ValorTotal { get; set; }
    }
}
