using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class LibroResponse : UseCaseResponseMessage
    {
        public string Mensaje { get; }
        public IEnumerable<Error> Errors { get; }

        public LibroResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LibroResponse(string mensaje, bool success = false, string message = null) : base(success, message)
        {
            Mensaje = mensaje;
        }
    }
}
