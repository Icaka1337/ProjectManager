using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Models;
using ProjectManager.Services;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext context;
        public TasksController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var tasks = context.Tasks.ToList();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return View(taskDto);
            }

            Task task = new Task
            {
                ProjectId = taskDto.Project.ProjectId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Status = taskDto.Status
            };

            context.Tasks.Add(task);
            context.SaveChanges();

            return RedirectToAction("Index", "Tasks");
        }

    }
}
