using Microsoft.AspNetCore.Authorization;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;

        public ProductController(ApplicationDBContext DbContext)
        {
            _dBContext = DbContext;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new InvalidOperationException();
                }
                _dBContext.products.Add(product);
                await _dBContext.SaveChangesAsync();
                return Ok("Product added successfully ");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("GetProduct")]

        public async Task<IActionResult> GetProduct()
        {
            var product = await _dBContext.products.Where(p=>p.isActive==true).ToListAsync();
            return Ok(product);
        }

        [HttpGet]
        [Route("GetProductById/{Id}")]

        public async Task<IActionResult> GetProductById(int Id)
        {
            if (Id == 0)
            {
                throw new InvalidOperationException();
            }
            var product = await _dBContext.products.Where(a => a.Prod_id == Id).FirstOrDefaultAsync();
            return Ok(product);

        }

        [HttpPut]
        [Route("UpdateProductById/{id}")]

        public async Task<IActionResult> UpdateProductByID (int id, [FromBody] Product newProductDetail)
        {
            if (id == 0)
            {
                throw new InvalidOperationException();
            }
            try
            {
                var oldDetails = await _dBContext.products.Where(x => x.Prod_id == id).FirstOrDefaultAsync();
                var newProduct = newProductDetail;
                oldDetails.PName = newProduct.PName;
                oldDetails.PMfdDate = newProduct.PMfdDate;
                oldDetails.PPrice = newProduct.PPrice;

                _dBContext.Entry(oldDetails).Property(x => x.PName).IsModified = true;
                _dBContext.Entry(oldDetails).Property(x => x.PMfdDate).IsModified = true;
                _dBContext.Entry(oldDetails).Property(x => x.PPrice).IsModified = true;

                _dBContext.SaveChanges();
                return Ok(oldDetails.Prod_id);

            }
            catch (Exception ex)
            {

                return NoContent();
            }
        }
        [HttpPut]
        [Route("HideProductById/{id}")]
        public async Task<IActionResult> HideProduct(int id)
        {
            if (id == 0)
            {
                //throw new InvalidOperationException
            }
            try
            {
                var product = await _dBContext.products.Where(a => a.Prod_id == id).FirstOrDefaultAsync();
                product .isActive = false;
                _dBContext.SaveChanges();
                return Ok("status changed ");

            }
            catch (Exception e)
            {
                return NoContent();
            }
        }

    }
}

