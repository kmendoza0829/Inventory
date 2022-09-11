using Inventory.Business.Core.Business;
using Inventory.Domain.Data.Models.Implementation;
using Inventory.Domain.Data.Models.Request;
using Inventory.Domain.Infrastructure.Exceptions;
using Inventory.Domain.Infrastructure.Request;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.User.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Post(CreateUserRequest request)
        {
            try
            {
                //Process
                string messageInsert = await _userBusiness.CreateUser(request);
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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                UserManager user = await _userBusiness.GetById(id);
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

        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                List<UserManager> users = _userBusiness.GetUsers();
                return Ok(users);
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

        [HttpPut("UpdateStatus/{id}")]
        public async Task<ActionResult> UpdateStatus(Guid id)
        {
            try
            {
                //Process
                string messageInsert = await _userBusiness.UpdateStatus(id);
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

        [HttpPut("Update")]
        public async Task<ActionResult> Update(UpdateUserRequest updateUserRequest)
        {
            try
            {
                //Process
                string messageInsert = await _userBusiness.Update(updateUserRequest);
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
