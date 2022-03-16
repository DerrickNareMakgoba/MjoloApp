using API.Data;
using API.Dto;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(UserDto _user)
        {
            var user = new AppUser {
                UserName = _user.UserName,
                Email = _user.Email
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
            
        }
    }
}