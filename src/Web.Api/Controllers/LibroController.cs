using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroUseCase _libroUseCase;

        public LibroController (ILibroUseCase libroUseCase)
        {
            _libroUseCase = libroUseCase;
        }

        [HttpPost("AdicionarLibro")]
        public ActionResult AdicionarLibro (LibroRequest libroRequest)
        {
            try
            {
                //bool resultdo = _libroUseCase.AdicionarLibro(libroRequest);

                return Ok(new LibroResponse("Libro guardado", true));
            }
            catch (Exception e)
            {
                return BadRequest(new LibroResponse(new[] { new Error("Error_Inernal", e.Message) }));
            }

        }

    }
}
