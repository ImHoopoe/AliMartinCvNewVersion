using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.ArticleGroupViewModels;
using AliMartinCv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace AliMartinCv.Areas.Controllers
{
    [Area("Admin")]
    public class ArticleGroupController : Controller
    {
        private readonly IArticleGroup _articleGroup;
        public ArticleGroupController(IArticleGroup articleGroup)
        {
            _articleGroup = articleGroup;
        }

        public async Task<IActionResult> Index()
        {
            var (articleGroups,message) = await _articleGroup.GetArticleGroups();
            return View(articleGroups);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var (groups,message) = await _articleGroup.GetArticleGroups();
            var selectListItems = new List<SelectListItem>();
            foreach (var group in groups)
            {
                SelectListItem sl = new SelectListItem()
                {
                    Text = group.Title,
                    Value = group.Id.ToString()
                };
                selectListItems.Add(sl);
            }
                CreateArticleGroupDto articleGroupDto = new CreateArticleGroupDto()
            {
                ArticleGroups = selectListItems
            };
            return View(articleGroupDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleGroupDto articleGroupDto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("choose your favorite door ! ");
            }
           await _articleGroup.CreateAsync(articleGroupDto);
            return RedirectToAction(nameof (Index));
        }

    }
}
