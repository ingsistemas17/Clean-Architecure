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

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }

    }
}
