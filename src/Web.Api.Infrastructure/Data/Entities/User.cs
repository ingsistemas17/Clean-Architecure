using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Web.Api.Infrastructure.Data.EntityFramework.Entities;

namespace Web.Api.Infrastructure.Data.Entities
{
    public class User: Entity<long>
    {

        public const int MaxPassLength = 128;


        [Required]
        [StringLength(MaxPassLength)]
        public string  Password {get; set;}

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(256)]
        public string EmailAddress { get; set; }



    }
}
