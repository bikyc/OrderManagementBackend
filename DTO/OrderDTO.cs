using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.DTO
{
    public class OrderDTO
    {

        public int customercust_Id { get; set; }

        public int productId { get; set; }

        public int quantity { get; set; }

        public int totalprice { get; set; }


    }
}
