using ApiUser.Api.Model;
using ApiUser.Application.Dtos;
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
        public async Task<IActionResult> Create([FromForm] Create request)
        {
            try
            {
                if (await _usersApplicationService.Create(new Users() { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Password = request.Password}))
                    return StatusCode(StatusCodes.Status201Created, "Uregistered successfully.");

                return StatusCode(StatusCodes.Status400BadRequest, "Already registered user.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to register." + ex.Message);
            }
        }

        [HttpPost("Login")]
        [SwaggerOperation(Summary = "Loggin.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromForm] Login request)
        {
            try
            {
                var user = await _usersApplicationService.ReadByEmail(request.Email);

                if (user != null)
                {
                    if (request.Password == user.Password)
                    {
                        return StatusCode(StatusCodes.Status200OK, new UsersDto() 
                        { 
                            Id = user.Id, 
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            Email = user.Email
                        });
                    }
                    return StatusCode(StatusCodes.Status400BadRequest, "Incorrect password.");
                }

                return StatusCode(StatusCodes.Status400BadRequest, "Incorrect email.");

            }
            catch (Exception ex)
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
        public async Task<IActionResult> Delete([FromForm] Delete request)
        {
            try
            {
                if (await _usersApplicationService.Delete(new Users() { Id = request.Id, FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Password = request.Password}))
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
        public async Task<IActionResult> Update([FromForm] Update request)
        {
            try
            {
                if (await _usersApplicationService.Update(new Users() { Id = request.Id,FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Password = request.Password}))
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
