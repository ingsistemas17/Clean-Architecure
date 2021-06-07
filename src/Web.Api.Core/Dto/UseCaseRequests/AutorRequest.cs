using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class AutorRequest
    {
        [Required]
        [MaxLength(200)]
        public string NombreCompleto { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string CiudadProcedencia { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Error con el formato del correo.")]       
        [Required]
        public string Correo { get; set; }


    }
}
