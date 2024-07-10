using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatikaCohortsProject.API.Base;
using PatikaCohortsProject.API.Model;
using PatikaCohortsProject.API.Services;

namespace PatikaCohortsProject.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _userService.GetByIdAsync(id);
            if (item == null)
            {
                var response = new ApiResponse<UserEntity>(404, "user not found in system.");
                return NotFound(response);
            }

            var successResponse = new ApiResponse<UserEntity>(200, "Success", item);
            return Ok(successResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            if (user == null)
            {
                return BadRequest(new ApiResponse<UserEntity>(400, "Invalid user data.", user));
            }
            _userService.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, new ApiResponse<UserEntity>(201, "user created successfully.", user));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<UserEntity>(400, "Invalid user data.", user));
            }

            var item = await _userService.GetByIdAsync(id);
            if (item == null)
            {
                var response = new ApiResponse<UserEntity>(404, "user not found in system.");
                return NotFound(response);
            }

            item.FirstName = user.FirstName;
            item.LastName = user.LastName;
            item.Email = user.Email;
            item.PhoneNumber = user.PhoneNumber;
            item.Age = user.Age;
            item.Gender = user.Gender;

            await _userService.UpdateAsync(item);
            var successResponse = new ApiResponse<List<UserEntity>>(200, "user updated successfully.");
            return Ok(successResponse);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var login = await _userService.Login(email, password);
            if (login)
            {
                var successResponse = new ApiResponse<UserEntity>(200, "Login successfully.");
                return Ok(successResponse);
            }
            var failedResponse = new ApiResponse<UserEntity>(500, "Login failed.");
            return BadRequest(failedResponse);
        }
    }
}
