using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using OrderManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;

        public CustomerController(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new InvalidOperationException();
                }
                _dBContext.customers.Add(customer);
                await _dBContext.SaveChangesAsync();
                return Ok(customer.cust_id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _dBContext.customers.ToListAsync();
            return Ok(customers);
        }


        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            if(id == 0)
            {
                throw new InvalidOperationException();
            }
            var customer = await _dBContext.customers.Where(a => a.cust_id == id).FirstOrDefaultAsync();
            return Ok(customer);
        }

        [HttpPut]
        [Route("UpdateCustomerById/{id}")]
        public async Task<IActionResult> PutCustomer(int id,[FromBody] Customer newDetails)
        {
            if (id == 0)
            {
                throw new InvalidOperationException();
            }
            //_dBContext.Entry(products).State = EntityState.Modified;
            try
            {
                //await _dBContext.SaveChangesAsync()
                var oldDetails = await  _dBContext.customers.Where(x => x.cust_id == id).FirstOrDefaultAsync();
                var newDetailFromUser = newDetails;
                oldDetails.email = newDetailFromUser.email;
                oldDetails.name = newDetailFromUser.name;
                oldDetails.address = newDetailFromUser.address;

                _dBContext.Entry(oldDetails).Property(x => x.email).IsModified = true;
                _dBContext.Entry(oldDetails).Property(x => x.name).IsModified = true;
                _dBContext.Entry(oldDetails).Property(x => x.address).IsModified = true;

                _dBContext.SaveChanges();
                return  Ok(oldDetails.cust_id);
            }
            catch (Exception ex)
            {
             
                return NoContent();
            }
           
        }

        [HttpDelete]
        [Route("DeleteCustomerById/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id== 0)
            {
                //throw new InvalidOperationException
            }
            try
            {
                var customer = await _dBContext.customers.Where(a => a.cust_id == id).FirstOrDefaultAsync();
                //_dBContext.Remove(customer);
                //_dBContext.SaveChanges();
                _dBContext.customers.Remove(customer);
                _dBContext.SaveChanges();
                return Ok("deleted scuccessfully");
                
            }
            catch(Exception e)
            {
                return NoContent();
            }
        }
        [HttpPut]
        [Route("HideCustomerById/{id}")]
        public async Task<IActionResult> HideCustomer(int id)
        {
            if (id == 0)
            {
                throw new InvalidOperationException();
            }
            try
            {
                var customer = await _dBContext.customers.Where(a => a.cust_id == id).FirstOrDefaultAsync();
                customer.isActive = false;
                _dBContext.SaveChanges();
                return Ok(customer);

            }
            catch (Exception e)
            {
                return NoContent();
            }
        }


    }

}



