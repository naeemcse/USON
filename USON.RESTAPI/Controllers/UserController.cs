using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USON.Application.DTOs;
using USON.Application.Interfaces;

namespace USON.RESTAPI.Controllers
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
        [HttpPost]
        public async Task<IActionResult> Create(RegisterUserDto userDto)
        {
            var created = await _userService.CreateAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, RegisterUserDto userDto)
        {
            var result = await _userService.UpdateAsync(id, userDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
