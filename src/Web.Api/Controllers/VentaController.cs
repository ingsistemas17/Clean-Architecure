using System;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaUseCase _venta;

        public VentaController (IVentaUseCase venta)
        {
            this._venta = venta;
        }
    


  
    [HttpGet("GetCliente/{Identificacion}")]
    public ActionResult GetCliente(decimal Identificacion)
    {
            try
            {
                var cliente = _venta.GetCliente(Identificacion);


                return Ok(new { 
                cliente.Nombres,
                cliente.Apellidos,
                cliente.IdCliente
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
                
    }

        [HttpGet("GetProduct/{Codigo}")]
        public ActionResult GetProduct(string Codigo)
        {
            try
            {
                var producto = _venta.GetProduct(Codigo);


                return Ok(new
                {
                    producto.IdProducto,
                    producto.Stock,
                    producto.ValorUnidad,
                    producto.Nombre
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpPost("RegistrarVenta")]
        public ActionResult RegistrarVenta(RegistrarVentaRequest registrarVenta)
        {
            try
            {
                var facturaDetalle = _venta.RegistrarVenta(registrarVenta);


                return Ok(new
                {
                    facturaDetalle.IdFactura,
                    facturaDetalle.FechaVenta,
                    facturaDetalle.ValorTotal
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}