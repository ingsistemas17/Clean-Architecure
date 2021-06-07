using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Core.Dto;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Entity;
using Web.Api.Core.Interfaces.UseCases;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroUseCase _libroUseCase;
        private readonly IMapper _mapper;

        public LibroController (ILibroUseCase libroUseCase, IMapper mapper)
        {
            _libroUseCase = libroUseCase;
            _mapper = mapper;
        }

        [HttpPost("AdicionarLibro")]
        public ActionResult AdicionarLibro (LibroRequest libroRequest)
        {
            try
            {
                Libro libro = _mapper.Map<Libro>(libroRequest);
                string resultado = _libroUseCase.AdicionarLibro(libro);

                return Ok(new LibroResponse(resultado , true));
            }
            catch (Exception e)
            {
                return BadRequest(new LibroResponse(new[] { new Error("Error_Inernal", e.Message) }));
            }

        }

        [HttpPost("AdicionarAutor")]
        public ActionResult AdicionarAutor(AutorRequest autorRequest)
        {
            try
            {
                Autor autor = _mapper.Map<Autor>(autorRequest);
                string resultado = _libroUseCase.AdicionarAutor(autor);

                return Ok(new LibroResponse(resultado, true));
            }
            catch (Exception e)
            {
                return BadRequest(new LibroResponse(new[] { new Error("Error_Inernal", e.Message) }));
            }

        }

        [HttpPost("AdicionarEditorial")]
        public ActionResult AdicionarEditorial(EditorialRequest editorialRequest)
        {
            try
            {
                Editorial editorial = _mapper.Map<Editorial>(editorialRequest);
                string resultado = _libroUseCase.AdicionarEditorial(editorial);

                return Ok(new LibroResponse(resultado, true));
            }
            catch (Exception e)
            {
                return BadRequest(new LibroResponse(new[] { new Error("Error_Inernal", e.Message) }));
            }

        }

        [HttpPost("BuscarLibros/{palabraClave}")]
        public ActionResult BuscarLibros(string  palabraClave)
        {
            try
            {

                List<Libro> resultado = _libroUseCase.BuscarLibros(palabraClave);
                List<LibroRequest> libroRequests = _mapper.Map<List<LibroRequest>>(resultado);
                
                return Ok(new LibroResponse(libroRequests, true));
            }
            catch (Exception e)
            {
                return BadRequest(new LibroResponse(new[] { new Error("Error_Inernal", e.Message) }));
            }

        }

    }
}
