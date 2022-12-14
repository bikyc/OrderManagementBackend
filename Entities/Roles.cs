using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class Roles : IdentityRole<string>
    {
        public string RoleType { get; set; }


        public ICollection<Users> Users { get; set; }
    }
}
