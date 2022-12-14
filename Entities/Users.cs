using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class Users : IdentityUser<string>
    {
        public int id { get; set; }

        public string username { get; set; }


        public string emial { get; set; }


        public string password { get; set; }

        public ICollection<Roles> Roles { get; set; }

    }
}
