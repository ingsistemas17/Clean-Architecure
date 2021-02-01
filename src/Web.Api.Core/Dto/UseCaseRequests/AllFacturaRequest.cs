using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Api.Core.Dto.Helper;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class AllFacturaRequest
    {
        [ValidationDuplicadoFactura]
        public FacturaRequest [] AllFacturas { get; set; }
    }
}
