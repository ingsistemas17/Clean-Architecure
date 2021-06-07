using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Interfaces;
using Web.Api.Infrastructure.Data.EntityFramework;
using System.Linq;
using Web.Api.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.Infrastructure.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly AppicationDbContext _dbContext;

        public Repository(AppicationDbContext context) => _dbContext = context;

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(long id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(long id) where T : BaseEntity
        {
            var a = _dbContext.Find<T>(id);
                       
            return a;
        }


        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }
        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Update<T>(entity);
            _dbContext.SaveChanges();
        }

        public List<Libro> Buscarlibros()
        {
            return _dbContext.Libro.Include(a => a.Autor).ToList();
        }

    }
}
