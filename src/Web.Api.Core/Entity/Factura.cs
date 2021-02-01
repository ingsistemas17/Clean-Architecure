using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Core.Entity
{

    [Table("TEST_FACTURA")]
    public class Factura : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("IdFacture", TypeName = "numeric(18,0)")]
        public decimal IdFacture { get; set; }

        [Required]
        [MaxLength(20)]
        public string NIT { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        [Required]
        public int IVA { get; set; }

        [Required]
        public double ValorTotalIva { get; set; }

    }


}
