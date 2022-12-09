using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class Product
    {
        [Key]
        public int Prod_id { get; set; }

        public String PName { get; set; }

        public DateTime PMfdDate { get; set; }

        public int PPrice { get; set; }

        [DefaultValue(true)]
        public Boolean isActive { get; set; } = true;

    }
}
