using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Entity;

namespace Web.Api.Core.Interfaces.UseCases
{
    public interface IVentaUseCase
    {

        Cliente GetCliente(decimal Identificacion);
        Producto GetProduct(string codigo);
        Factura RegistrarVenta(RegistrarVentaRequest registrarVenta);
    }
}
