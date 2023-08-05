using API_Demo.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared1.Models;

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //chỉ có admin mới thêm được sản phẩm
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateNewProduct(Product product)
        {
            try
            {
                if(product == null)
                {
                    return BadRequest();
                }
                else
                {
                    var newProduct = await _productService.AddProductAsync(product);
                    return Ok(newProduct);
                }    
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var result = await _productService.GetProductsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}
