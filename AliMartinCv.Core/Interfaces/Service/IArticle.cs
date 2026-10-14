using AliMartinCv.Core.ViewModels.Article;
using AliMartinCv.Core.ViewModels.ArticleGroupViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Service
{
    public interface IArticle
    {
        Task<(bool Success, string? Message)> CreateAsync(CreateArticleDto create);
        Task<(bool Success, string? Message)> UpdateAsync(UpdateArticleDto update);
        Task<(bool Success, string? Message)> DeleteAsync(DeleteArticleDto delete);
        Task<(ArticleDto? article, string? Message)> GetArticle(int id);
        Task<(IEnumerable<ArticleDto> article, string? Message)> GetArticles(int? pageNumber = 1,int? skip = 10);
        Task<(bool exists, string message)> IsExists(int id);
    }
}
