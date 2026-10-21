using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.Project;
using AliMartinCv.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectsController : Controller
    {
        private readonly IProject _projectService;
        public ProjectsController(IProject projectService)
        {
            _projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            var (projects, message) = await _projectService.GetProjects();
            return View(projects);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto createProjectDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createProjectDto);
            }
            var (success, message) = await _projectService.CreateAsync(createProjectDto);
            if (!success)
            {
                TempData["Error"] = "خطا در افزودن پروژه !";
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "افزودن موفق";
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var (exists, message) = await _projectService.IsExists(id);
            if (!exists)
            {
                return RedirectToAction(nameof(Index));
            }
            var (entity, msg) = await _projectService.GetProject(id);
            UpdateProjectDto updateProjectDto = new UpdateProjectDto()
            {
                Id = id,
                Description = entity.Description,
                ShortDescription = entity.ShortDescription,
                Slug = entity.Slug,
                Title = entity.Title,
            };
            return View(updateProjectDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProjectDto updateProjectDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateProjectDto);
            }
            var (success, msg) = await _projectService.UpdateAsync(updateProjectDto);
            if (!success)
            {
                TempData["Error"] = "خطا در ویرایش پروژه !";
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "ویرایش موفق";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                TempData["Error"] = "شناسه نامعتبر";
                return RedirectToAction(nameof(Index));
            }
            var (exists, msg) = await _projectService.IsExists(id);
            if (!exists)
            {
                TempData["Error"] = "شناسه نامعتبر";
                return RedirectToAction(nameof(Index));
            }
            var (dto, message) = await _projectService.GetProject(id);
            if (dto == null)
            {
                TempData["Error"] = "شناسه نامعتبر";
                return RedirectToAction(nameof(Index));
            }
            DeleteProjectDto deleteProjectDto = new DeleteProjectDto()
            {
                Id = id,
                Title = dto.Title

            };
            return View(deleteProjectDto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProjectDto deleteProjectDto)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteProjectDto);
            }
            var (success,message) = await _projectService.DeleteAsync(deleteProjectDto);
            if (!success)
            {
                TempData["Error"] = "خطا در حذف";
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "حذف موفق";
            return RedirectToAction(nameof(Index));
        }



    }
}
