using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Entities
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }

        public DateTime orderDate { get; set; }


        public Customer customer { get; set; }

        public Product product { get; set; }

        public int quantity { get; set; }

        public int totalPrice { get; set; }


        public string OrderStatus { get; set; } 

        [DefaultValue(true)]
        public Boolean isActive { get; set; } = true;
    }
}
