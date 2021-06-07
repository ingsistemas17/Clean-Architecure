using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class EditorialRequest
    {
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [Required]
        public string DireccionCorrespondencia { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Error con el formato del correo.")]
        public string Correo { get; set; }

        [Required]
        public int MaxLibros { get; set; }

    }
}
