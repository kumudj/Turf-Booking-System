
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TurfBooking.DTO;
using TurfBooking.Models;
using TurfBooking.Services;

namespace TurfBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching users: {ex.Message}");
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetUser(int id)
        {
            try
            {
                var user = _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while fetching the user with ID {id}: {ex.Message}");
            }
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<UserDTO> PostUser(NewUserDTO newUserDto)
        {
            try
            {
                var help = _userService.AddUser(newUserDto);
                var createdUser = _userService.GetUser(help.Id); // Assuming the service returns the created user
                return CreatedAtAction("GetUser", new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while creating a new user: {ex.Message}");
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, UserDTO userDto)
        {
            try
            {
                if (id != userDto.Id)
                {
                    return BadRequest();
                }
                _userService.UpdateUser(id, userDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while updating the user with ID {id}: {ex.Message}");
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, $"An error occurred while deleting the user with ID {id}: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] login request)
        {
            try
            {
                // Generate a bearer token. This is a placeholder. Use a secure method to generate tokens.
                var token = _userService.Login(request);
                //if (token == "Incorrect Credentials")
                if (token.token == "1")
                {
                    // Throw an exception if token.Id is null
                    return Unauthorized("Invalid Username or password or Token Id is null");
                }
                // Return the token as JSON
                return Ok(token);
            }
            catch (NullReferenceException ex)
            {
                // Return an error response if the credentials are invalid or token.Id is null
                // return Ok("Invalid Username or password or Token ID is null");
                return Unauthorized("Invalid Username or password or Token ID is null");
            }
            catch (Exception ex)
            {
                // Log the exception or handle other types of exceptions
                return StatusCode(500, $"An error occurred during the login process: {ex.Message}");
            }
        }
    }
}
