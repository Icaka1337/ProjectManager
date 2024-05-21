using Microsoft.AspNetCore.Mvc;
using ProjectManager.Services;

namespace ProjectManager.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProjectsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var projects = context.Projects.ToList();
            return View(projects);
        }
    }
}
