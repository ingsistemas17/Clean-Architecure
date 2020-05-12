using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class RegistrarProductoRequest
    {
        [Required]
        public decimal IdProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }
    }
}
