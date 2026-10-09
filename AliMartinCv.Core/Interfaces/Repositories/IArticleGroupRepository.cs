using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{
    public interface IArticleGroupRepository
    {
        Task<bool> Create(ArticleGroup articleGroup);
        Task<bool> Update(ArticleGroup articleGroup);
        Task<bool> Delete(ArticleGroup articleGroup);
        Task<ArticleGroup> GetArticleGroup(int articleGroupId);
        Task<IEnumerable<ArticleGroup>> GetArticleGroups();
    }
}
