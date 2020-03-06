using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Web.Api.Infrastructure.Data.EntityFramework.Entities
{
    public abstract class Entity <TPrimaryKey>
    {
        protected Entity() { }

        // Summary:
        //     Unique identifier for this entity.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual TPrimaryKey Id { get; set; }

        public int? TenantId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
