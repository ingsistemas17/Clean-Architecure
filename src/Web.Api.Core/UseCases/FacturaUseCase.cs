using System;
using System.Linq;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Core.UseCases
{
    public class FacturaUseCase : IFacturaUseCase
    {
        public double SumAllFactura(AllFacturaRequest allFactura)
        {

            return allFactura.AllFacturas.Sum(a => a.ValorTotal);
        }

        private void CalculaTotalImpuesto(FacturaRequest[] allFacturas)
        {
            throw new NotImplementedException();
        }
    }
}
