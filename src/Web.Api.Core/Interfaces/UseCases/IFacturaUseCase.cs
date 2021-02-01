using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Interfaces.UseCases
{
    public interface IFacturaUseCase
    {
        double SumAllFactura(AllFacturaRequest allFacture);
    }
}
