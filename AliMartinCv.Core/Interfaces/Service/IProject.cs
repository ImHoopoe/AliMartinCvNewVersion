using AliMartinCv.Core.ViewModels.ArticleGroupViewModels;
using AliMartinCv.Core.ViewModels.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Service
{
    public interface IProject
    {
        Task<(bool Success, string? Message)> CreateAsync(CreateProjectDto create);
        Task<(bool Success, string? Message)> UpdateAsync(UpdateProjectDto update);
        Task<(bool Success, string? Message)> DeleteAsync(DeleteProjectDto delete);
        Task<(ProjectDto? Projects, string? Message)> GetProject(int id);
        Task<(IEnumerable<ProjectDto> Projects, string? Message)> GetProjects();
        Task<(bool exists, string message)> IsExists(int id);


    }
}
