using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Entity;

namespace Web.Api.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(long id) where T : BaseEntity;

        List<T> List<T>() where T : BaseEntity;

        T Add<T>(T entity) where T : BaseEntity;

        void Update<T>(T entity) where T : BaseEntity;

        void Delete<T>(T entity);

        void Delete<T>(long id);

        List<Libro> Buscarlibros();
    }
}
