﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class UserRole 
    {
     public Users users { get; set; }

        public Roles role { get; set; }

    }
}
