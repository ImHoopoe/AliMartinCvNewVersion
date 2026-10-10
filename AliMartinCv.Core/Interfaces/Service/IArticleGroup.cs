using AliMartinCv.Core.ViewModels.ArticleGroupViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Service
{
    public interface IArticleGroup
    {
        //CRUD
        Task<(bool Success, string? Message)> CreateAsync(CreateArticleGroupDto create);
        Task<(bool Success, string? Message)> UpdateAsync(UpdateArticleGroupDto update);
        Task<(bool Success, string? Message)> DeleteAsync(DeleteArticleGroupDto delete);
        Task<(ArticleGroupDto? articleGroup, string? Message)> GetArticleGroup(int id);
        Task<(IEnumerable<ArticleGroupDto> articleGroups, string? Message)> GetArticleGroups();

    }
}
