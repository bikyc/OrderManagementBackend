using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using OrderManagement.DTO;
using OrderManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataAccess.ApplicationDBContext _dBContext;

        public OrderController(DataAccess.ApplicationDBContext applicationDBContext)
        {
            _dBContext = applicationDBContext;
        }

        [HttpPost]
        [Route("AddOrder")]

        public async Task<IActionResult> AddOrder ([FromBody] OrderDTO orderDTO)
        {
            if(orderDTO == null)
            {
                throw new ArgumentNullException();
            }

            var customer = await _dBContext.customers.Where(a => a.cust_id == orderDTO.customercust_Id && a.isActive== true).FirstOrDefaultAsync();
            var product = await _dBContext.products.Where(a => a.Prod_id == orderDTO.productId && a.isActive==true).FirstOrDefaultAsync();
            Order order = new Order();

            order.customer = customer;
            order.product = product;
            order.orderDate = DateTime.Now;
            order.quantity = orderDTO.quantity;
            order.totalPrice = orderDTO.quantity*product.PPrice;

            _dBContext.orders.Add(order);
           await _dBContext.SaveChangesAsync();

            return Ok(order.order_id);
        }

        [HttpGet]
        [Route("GetOrders")]

        public async Task<IActionResult> GetOrders()
        {
            var orders = await _dBContext.orders.Where(a => a.isActive == true).Include(a=>a.customer).Include(b=>b.product).ToListAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrdersById/{id}")]

        public async Task<IActionResult> GetOrders(int id)
        {
            if (id == 0)
            {
                throw new InvalidOperationException();
            }
            var orders = await _dBContext.orders.Where(o=> o.order_id==id).Include(a => a.customer).Include(b => b.product).ToListAsync();
            return Ok(orders);
        }
        [HttpPut]
        [Route("UpdateOrderById/{id}")]
        public async Task<IActionResult> updateOrder(int id, [FromBody] OrderDTO orderDTO)
        {
            if (id == 0)
            {
                throw new InvalidOperationException();
            }
            //_dBContext.Entry(products).State = EntityState.Modified;
            try
            {
                //await _dBContext.SaveChangesAsync()
                var order = await _dBContext.orders.Where(x => x.order_id == id).Include(b=>b.product).FirstOrDefaultAsync();
                order.quantity = orderDTO.quantity;
                order.totalPrice = orderDTO.quantity * order.product.PPrice;

                _dBContext.Entry(order).Property(x => x.quantity).IsModified = true;
                _dBContext.Entry(order).Property(x => x.totalPrice).IsModified = true;


               await _dBContext.SaveChangesAsync();
                return Ok("Update Done");
            }
            catch (Exception ex)
            {

                return NoContent();
            }

        }
        [HttpPut]
        [Route("HideOrderById/{id}")]
        public async Task<IActionResult> HideOrder(int id)
        {
            if (id == 0)
            {
                //throw new InvalidOperationException
            }
            try
            {
                var order = await _dBContext.orders.Where(a => a.order_id == id).FirstOrDefaultAsync();
                order.isActive = false;
               await _dBContext.SaveChangesAsync();
                return Ok("status changed ");

            }
            catch (Exception e)
            {
                return NoContent();
            }
        }

    }

}
