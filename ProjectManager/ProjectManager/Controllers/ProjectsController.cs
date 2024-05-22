using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectDto projectDto)
        {

            if (!ModelState.IsValid)
            {
                return View(projectDto);
            }

            //Save the new project in database

            Project project = new Project()
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                Budget = projectDto.Budget,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
            };

            context.Projects.Add(project);
            context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }

        public IActionResult Edit(int id)
        {
            var project = context.Projects.Find(id);

            if (project == null)
            {
                return RedirectToAction("Index", "Projects");
            }

            var projectDto = new ProjectDto()
            {
                Name = project.Name,
                Description = project.Description,
                Budget = project.Budget,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
            };

            ViewData["ProjectId"] = project.ProjectId;

            return View(projectDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProjectDto projectDto)
        {
            var project = context.Projects.Find(id);

            if (project == null)
            {
                return RedirectToAction("Index", "Projects");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ProjectId"] = project.ProjectId;
                return View(projectDto);
            }

            project.Name=projectDto.Name;
            project.Description=projectDto.Description;
            project.Budget=projectDto.Budget;
            project.StartDate=projectDto.StartDate;
            project.EndDate=projectDto.EndDate;

            context.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }

        public IActionResult ShowTasksResult(int id)
        {
            var tasksForProject = context.Tasks.Where(p => p.ProjectId == id).ToList();
            return View(tasksForProject);
        }
    }
}
