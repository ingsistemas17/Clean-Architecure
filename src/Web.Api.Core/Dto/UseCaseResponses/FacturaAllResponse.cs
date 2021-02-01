using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class FacturaAllResponse : UseCaseResponseMessage
    {
        public double SumaTotal { get; }
        public IEnumerable<Error> Errors { get; }

        public FacturaAllResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public FacturaAllResponse(double sumaTotal, bool success = false, string message = null) : base(success, message)
        {
            SumaTotal = sumaTotal;
        }
    }
}
