using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        //CRUD
        Task<bool> CreateAsync(Project project);
        Task<bool> UpdateAsync(Project project);
        Task<bool> DeleteAsync(Project project);
        Task<Project> GetProject(int id);
        Task<IEnumerable<Project>> GetProjectsAsync();

    }
}
