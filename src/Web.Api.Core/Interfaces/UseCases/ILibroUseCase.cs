using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Entity;

namespace Web.Api.Core.Interfaces.UseCases
{
    public interface ILibroUseCase 
    {
        string AdicionarLibro(Libro libro);
        string AdicionarEditorial(Editorial editorial);
        string AdicionarAutor(Autor autor);
        List<Libro> BuscarLibros(string palabraClave);

    }
}
