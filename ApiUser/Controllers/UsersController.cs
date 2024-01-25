using ApiUser.Application.Interfaces.ApplicationServices;
using ApiUser.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersApplicationService _usersApplicationService;
        public UsersController(IUsersApplicationService usersApplicationService)
        {
            _usersApplicationService = usersApplicationService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Register new user.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Users request)
        {
            try
            {
                if (await _usersApplicationService.Create(request))
                    return StatusCode(StatusCodes.Status201Created, "Uregistered successfully.");

                return StatusCode(StatusCodes.Status400BadRequest, "Already registered user.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to register." + ex.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Read all users.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ReadAll([FromQuery] Users request)
        {
            try
            {
                return Ok(await _usersApplicationService.ReadAll(request));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to read users." + ex.Message);
            }
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete a user.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] Users request)
        {
            try
            {
                if (await _usersApplicationService.Delete(request))
                    return StatusCode(StatusCodes.Status200OK, "Deleted successfully.");

                return StatusCode(StatusCodes.Status404NotFound, "User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to delete." + ex.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a user.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] Users request)
        {
            try
            {
                if (await _usersApplicationService.Update(request))
                    return StatusCode(StatusCodes.Status200OK, "Updated successfully.");

                return StatusCode(StatusCodes.Status404NotFound, "User not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to register." + ex.Message);
            }
        }
    }
}
