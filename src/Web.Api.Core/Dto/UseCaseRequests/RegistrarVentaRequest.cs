using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class RegistrarVentaRequest
    {
        [Required]
        public decimal IdCliente { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }


        [Required]
        public List<RegistrarProductoRequest> Productos { get; set; }


    }
}
