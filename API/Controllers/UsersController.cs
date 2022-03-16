using API.Data;
using API.Dto;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<AppUser>>> PostUsersAsync(UserDto _user)
        {
            var user = new AppUser {
                UserName = _user.UserName,
                Email = _user.Email,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
             _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
    
}