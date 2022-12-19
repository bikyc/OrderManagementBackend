using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.DTO
{
    public class UserDTO
    {
        public string username { get; set; }


        public string email { get; set; }


        public string password { get; set; }
        public string Role { get; internal set; }
    }
}
