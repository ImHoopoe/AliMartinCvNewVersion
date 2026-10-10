using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{
    public interface IArticleGroupRepository
    {
        Task<bool> CreateAsync(ArticleGroup articleGroup);
        Task<bool> UpdateAsync(ArticleGroup articleGroup);
        Task<bool> DeleteAsync(ArticleGroup articleGroup);
        Task<ArticleGroup> GetArticleGroupAsync(int articleGroupId);
        Task<IEnumerable<ArticleGroup>> GetArticleGroupsAsync();
    }
}
