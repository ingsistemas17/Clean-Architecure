using Microsoft.AspNetCore.Mvc;
using System;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaUseCase _facturaUseCase;

        public FacturaController(IFacturaUseCase facturaUseCase)
        {
            _facturaUseCase = facturaUseCase;
        }

        [HttpPost("GetAllFactura")]
        public ActionResult GetAllFactura(AllFacturaRequest allFacture)
        {
            try
            {
                double sumTotal = _facturaUseCase.SumAllFactura(allFacture);

                return Ok(new FacturaAllResponse(sumTotal, true));
            }
            catch (Exception e)
            {
                return BadRequest(new FacturaAllResponse( new[] { new Error("Error_Inernal", e.Message) }) );
            }

        }

        [HttpPost("GetTotalIvaFactura")]
        public ActionResult GetTotalIvaFactura (FacturaRequest factura)
        {
            try
            {
                double total = factura.ValorTotalIva;

                return Ok(new FacturaAllResponse(total, true));
            }
            catch (Exception e)
            {
                return BadRequest(new FacturaAllResponse(new[] { new Error("Error_Inernal", e.Message) }));
            }

        }
    }
}
