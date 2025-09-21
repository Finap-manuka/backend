using Microsoft.AspNetCore.Mvc;
using finap.Models;
using finap.DTOs;
using finap.Data;


namespace EmployeePortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password, // ⚠️ hash later
                Role = dto.Role,
                StartDate = dto.StartDate
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                StartDate = user.StartDate
            });
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                StartDate = u.StartDate
            }).ToList();

            return Ok(users);
        }
    }
}
