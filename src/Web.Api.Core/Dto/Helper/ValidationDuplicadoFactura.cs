using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using Web.Api.Core.Dto.UseCaseRequests;

namespace Web.Api.Core.Dto.Helper
{
    public class ValidationDuplicadoFactura: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            FacturaRequest [] facturaRequests = value as  FacturaRequest[];
            var idFactures = facturaRequests.Select(a => a.IdFacture );

            ValidationResult result = ValidationResult.Success;

            if (idFactures.Count() != idFactures.Distinct().Count())
            {
                result = new ValidationResult($"The field IdFacture contains duplicates.");
            }


            return result;
        }
    }
}
