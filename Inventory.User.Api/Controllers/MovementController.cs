using Inventory.Business.Core.Business;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.User.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : Controller
    {
        private readonly IMovementBusiness _movementBusiness;

        public MovementController(IMovementBusiness movementBusiness)
        {
            _movementBusiness = movementBusiness;
        }


        [HttpPost("Create")]
        public async Task<ActionResult> Post(CreateMovementRequest request)
        {
            try
            {
                //Process
                string messageInsert = await _movementBusiness.Create(request);
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
