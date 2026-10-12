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
            var (articleGroups, message) = await _articleGroup.GetArticleGroups();
            return View(articleGroups);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var (groups, message) = await _articleGroup.GetArticleGroups();
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
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var (isexist, message) = await _articleGroup.IsExists(id);
            if (!isexist)
            {
                TempData["message"] = message;
                return Redirect(nameof(Index));
            }


            var (groups, statusError) = await _articleGroup.GetArticleGroups();
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
            var (articleGroup, status) = await _articleGroup.GetArticleGroup(id);
            UpdateArticleGroupDto editDto = new UpdateArticleGroupDto()
            {
                Id = articleGroup.Id,
                Title = articleGroup.Title,
                ParentId = articleGroup.ParentId,
                ArticleGroups = selectListItems,
            };
            return View(editDto);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateArticleGroupDto updateArticleGroupDto)
        {
            if (!ModelState.IsValid)
            {
                var (groups, statusError) = await _articleGroup.GetArticleGroups();
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
                updateArticleGroupDto.ArticleGroups = selectListItems;
                TempData["Error"] = "فیلد ها را بررسی کنید";
                return View(updateArticleGroupDto);

            }
            var (success, messageResult) = await _articleGroup.UpdateAsync(updateArticleGroupDto);
            if (!success)
            {
                TempData["Error"] = messageResult;
                var (groups, statusError) = await _articleGroup.GetArticleGroups();
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
                updateArticleGroupDto.ArticleGroups = selectListItems;
                TempData["Error"] = "فیلد ها را بررسی کنید";
                return View(updateArticleGroupDto);
            }
            TempData["Message"] = messageResult;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var (isExists, message) = await _articleGroup.IsExists(id);
            if (!isExists)
            {
                TempData["Error"] = message;
                return RedirectToAction(nameof(Index));
            }
            var (articleGroup, error) = await _articleGroup.GetArticleGroup(id);
            DeleteArticleGroupDto deleteDto = new DeleteArticleGroupDto()
            {
                Id = id,
                Title = articleGroup.Title
            };
            return View(deleteDto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteArticleGroupDto deleteDto)
        {
            if (deleteDto == null)
            {
                TempData["Error"] = "برو عمتو مسخره کن";
                return RedirectToAction(nameof(Index));
            }
            var(status,message) = await _articleGroup.DeleteAsync(deleteDto);
            if (!status)
            {
                TempData["Error"] = "فرآیند حذف خطا داد";
                return RedirectToAction(nameof(Index));
            }
            TempData["message"] = "سیکش خورده شد";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var (articleGroup, message) = await _articleGroup.GetArticleGroup(id);
            return View(articleGroup);
        }
    }
}
