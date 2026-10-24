using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.Index;
using AliMartinCv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AliMartinCv.Controllers
{
    public class HomeController : Controller
    {
        public readonly IProject _projectService;
        public readonly IArticle _articleService;

        public HomeController(IProject projectService, IArticle articleService)
        {
            _projectService = projectService;
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            IndexDto indexDto = new IndexDto();
            var (articles, articlesMessage) = await _articleService.GetArticles();
            var (projects, projectsMessage) = await _projectService.GetProjects();
            indexDto.Articles = articles.ToList();
            indexDto.Projects = projects.ToList();
            return View(indexDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
