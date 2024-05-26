using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services;

namespace ProjectManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }
    }
}
