using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{

    [Table("TEST_FACTURA")]
    public class Factura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("IdFactura", TypeName = "numeric(18,0)")]
        public decimal IdFactura { get; set; }


        [ForeignKey("IdCliente")]
        public Cliente ClienteEntity { get; set; }
        [Required]
        [Column("IdCliente", TypeName = "numeric(18,0)")]
        public decimal IdCliente { get; set; }

        [Required]
        public DateTime FechaVenta { get; set; }

        [Required]
        [Column("ValorTotal", TypeName = "numeric(18,3)")]
        public decimal ValorTotal { get; set; }

    }


}
