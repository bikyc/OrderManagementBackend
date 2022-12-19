using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    [Index(nameof(username), IsUnique = true)]
    public class Users 
    {
        [Key]
        public int id { get; set; }

        public string username { get; set; }

        public string email { get; set; }


        public string password { get; set; }

        public ICollection<Roles> Roles { get; set; }

    }
}
