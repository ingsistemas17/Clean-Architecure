using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Api.Core.Dto.UseCaseRequests
{
    public class LibroRequest
    {

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int Anou { get; set; }

        [Required]
        public int NuPaginas { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public long EditorialId { get; set; }

        [Required]
        public long AutorId { get; set; }

        public string AutorNombre { get; set; }

    }
}
