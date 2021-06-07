using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.Core.Entity;
using Web.Api.Infrastructure.Data.Entities;

namespace Web.Api.Infrastructure.Data.EntityFramework
{
    public class AppicationDbContext : DbContext
    {

        public AppicationDbContext(DbContextOptions options)
        : base(options)
        {
        }


        //public DbSet<Factura> Facturas { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {

            //ModelBuilder.Entity<Libro>()
            //    .HasOne(d => d.Autor)
            //    .WithMany(s => s.Libros)
            //    .HasForeignKey(d => d.AutorId)
            //    .IsRequired(); 

                }

    }
}
