using API.Data;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            this._context = context;
        }
    }
}