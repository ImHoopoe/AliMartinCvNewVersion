using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{

    public interface IArticleRepository
    {
        Task<bool> CreateAsync(Article article);
        Task<bool> UpdateAsync(Article article);
        Task<bool> DeleteAsync(Article article);
        Task<Article> GetArticleAsync(int articleId);
        Task<Article> GetArticleAsync(string slug);
        Task<IEnumerable<Article>> GetArticlesAsync();

    }

}
