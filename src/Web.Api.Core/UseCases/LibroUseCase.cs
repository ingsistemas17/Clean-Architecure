using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Entity;
using Web.Api.Core.Interfaces;
using Web.Api.Core.Interfaces.UseCases;
using System.Linq;

namespace Web.Api.Core.UseCases
{

   

    public class LibroUseCase : ILibroUseCase
    {
        private readonly IRepository _repository;

        private readonly string LIBRO_SAVE = "GUARDAR_LIBRO_OK";
        private readonly string EDITORIAL_SAVE = "GUARDAR_EDITORIAL_OK";
        private readonly string AUTOR_SAVE = "GUARDAR_AUTOR_OK";
        private readonly string NOTEXIST_AUTOR = "El autor no está registrado.";
        private readonly string NOTEXIST_EDITORIAL = "La editorial no está registrada.";
        private readonly string MAX_LIBROS = "No es posible registrar el libro, se alcanzó el máximo permitido.";



        public LibroUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public string AdicionarLibro(Libro libro)
        {
            Autor autor = _repository.GetById<Autor>(libro.AutorId);
            Editorial editorial = _repository.GetById<Editorial>(libro.EditorialId);
            List<Libro> libros = null;
            string mensaje = string.Empty;

            if (autor == null)
                throw new Exception(NOTEXIST_AUTOR);

            if (editorial == null)
                throw new Exception(NOTEXIST_EDITORIAL);
            else
            {
                libros = _repository.List<Libro>().Where(a => a.EditorialId == libro.EditorialId).ToList();

                if(editorial.MaxLibros == -1 || libros.Count < editorial.MaxLibros)
                {
                    _repository.Add<Libro>(libro);
                    mensaje = LIBRO_SAVE;
                }else
                {
                    throw new Exception(MAX_LIBROS);
                }

            }
                
                return mensaje;                           
        }

        public string AdicionarEditorial(Editorial editorial)
        {
            _repository.Add<Editorial>(editorial);
            return EDITORIAL_SAVE;
        }

        public string AdicionarAutor(Autor autor)
        {
            _repository.Add<Autor>(autor);
            return AUTOR_SAVE;
        }

        public List<Libro> BuscarLibros(string palabraClave )
        {
            int anou = 0;
            int.TryParse(palabraClave, out anou);
            List<Libro> libros = _repository.Buscarlibros().Where(a => a.Titulo.ToUpper().Contains(palabraClave.ToUpper()) || a.Autor.NombreCompleto.ToUpper().Contains(palabraClave.ToUpper()) || (anou != 0 && a.Anou == anou)).ToList();


            return libros;

        }
    }
}
