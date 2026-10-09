using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{

    public interface IArticleRepository
    {
        Task<bool> Create(Article article);
        Task<bool> Update(Article article);
        Task<bool> Delete(Article article);
        Task<Article> GetArticle(int articleId);
        Task<Article> GetArticle(string slug);
        Task<IEnumerable<Article>> GetArticles();

    }

}
