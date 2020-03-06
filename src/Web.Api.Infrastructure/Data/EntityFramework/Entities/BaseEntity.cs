using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public  class BaseEntity : Entity<int>
    {

        protected BaseEntity() { }

    }
}
