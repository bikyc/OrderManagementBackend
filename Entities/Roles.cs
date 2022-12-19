using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class Roles 
    {
        public string RoleType { get; set; }

        [Key]
        public int roleid { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
