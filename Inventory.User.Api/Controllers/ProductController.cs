using Inventory.Business.Core.Business;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Post(CreateProductRequest request)
        {
            try
            {
                //Process
                string messageInsert = await _productBusiness.CreateProduct(request);
                return Ok(messageInsert);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server Error {ex.Message}");
            }
        }

        [HttpGet("GetByCode/{code}")]
        public async Task<ActionResult> GetByCode(string code)
        {
            try
            {
                ProductManager user = await _productBusiness.GetByCode(code);
                return Ok(user);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server Error {ex.Message}");
            }
        }

        [HttpGet("GetProducts")]
        public ActionResult GetProducts()
        {
            try
            {
                List<ProductManager> products = _productBusiness.GetUsers();
                return Ok(products);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server Error {ex.Message}");
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update(UpdateProductRequest updateProductRequest)
        {
            try
            {
                //Process
                string messageInsert = await _productBusiness.Update(updateProductRequest.Code, updateProductRequest.AlertMin, updateProductRequest.Stock);
                return Ok(messageInsert);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server Error {ex.Message}");
            }
        }
    }
}
