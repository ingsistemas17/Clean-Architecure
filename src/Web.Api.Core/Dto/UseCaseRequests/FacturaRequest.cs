using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class FacturaRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int IdFacture { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Numbers are only allowed.")]
        public string NIT { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double ValorTotal { get; set; }

        [Required]
        [Range(0, 100)]
        public int IVA { get; set; }

        public double ValorTotalIva { get { return (ValorTotal * IVA/100) + ValorTotal; } }

    }
}
