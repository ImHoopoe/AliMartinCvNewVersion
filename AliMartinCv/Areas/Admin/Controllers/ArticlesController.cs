using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly IArticle _articleService;
        private readonly IArticleGroup _articleGroupService;
        public ArticlesController(IArticle articleService, IArticleGroup articleGroupService)
        {
            _articleService = articleService;
            _articleGroupService = articleGroupService;
        }

        public async Task<IActionResult> Index()
        {
            var (articles, msg) = await _articleService.GetArticles();
            return View(articles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var (groups, msg) = await _articleGroupService.GetArticleGroups();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var g in groups)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = g.Title,
                    Value = g.Id.ToString(),
                };
                list.Add(selectItem);
            }
            CreateArticleDto createArticleDto = new CreateArticleDto()
            {
                ArticleGroups = list
            };
            return View(createArticleDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleDto createArticleDto)
        {
            if (!ModelState.IsValid)
            {
                var (groups, msg) = await _articleGroupService.GetArticleGroups();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var g in groups)
                {
                    SelectListItem selectItem = new SelectListItem
                    {
                        Text = g.Title,
                        Value = g.Id.ToString(),
                    };
                    list.Add(selectItem);
                }
                createArticleDto.ArticleGroups = list;
                return View(createArticleDto);
            }
            var (success, message) = await _articleService.CreateAsync(createArticleDto);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var (exists, message) = await _articleService.IsExists(id);
            if (!exists)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            var (article, Message) = await _articleService.GetArticle(id);
            var (groups, msg) = await _articleGroupService.GetArticleGroups();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var g in groups)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = g.Title,
                    Value = g.Id.ToString(),
                };
                list.Add(selectItem);
            }
            UpdateArticleDto updateArticleDto = new UpdateArticleDto()
            {
                ArticleGroups = list,
                Description = article.Description,
                ShortDescription = article.ShortDescription,
                Id = id,
                Slug = article.Slug,
                Tags = string.Join(",", article.Tags),
                Title = article.Title,

            };

            return View(updateArticleDto);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateArticleDto updateArticleDto)
        {
            if (!ModelState.IsValid)
            {
                var (groups, msg) = await _articleGroupService.GetArticleGroups();
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var g in groups)
                {
                    SelectListItem selectItem = new SelectListItem
                    {
                        Text = g.Title,
                        Value = g.Id.ToString(),
                    };
                    list.Add(selectItem);
                }
                updateArticleDto.ArticleGroups = list;
                return View(updateArticleDto);

            }
            var (success, message) = await _articleService.UpdateAsync(updateArticleDto);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                throw new Exception("به آیدی دست نزنید با تشکر");
            }
            var (exists, message) = await _articleService.IsExists(id);
            if (!exists)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            var (Entity, msg) = await _articleService.GetArticle(id);
            DeleteArticleDto deleteArticleDto = new DeleteArticleDto
            {
                Id = id,
                Title = Entity.Title

            };
            return View(deleteArticleDto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteArticleDto deleteArticleDto)
        {
            if (!ModelState.IsValid)
            {
                return View(deleteArticleDto);
            }
            var (success, message) = await _articleService.DeleteAsync(deleteArticleDto);
            if (!success)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }
    }
}
