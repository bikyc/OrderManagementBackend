using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class Customer
    {
        [Key]
        public int cust_id { get; set; }

        public string name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string email { get; set; }

        public string Role { get; set; }

        public string address { get; set; }

        [DefaultValue(true)]
        public Boolean isActive { get; set; } = true;


    }
}
