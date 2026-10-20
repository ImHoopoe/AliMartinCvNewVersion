using AliMartinCv.Core.Entities;
using AliMartinCv.Core.Interfaces.Repositories;
using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.Project;
using AliMartinCv.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Services
{
    public class ProjectService : IProject
    {
        private readonly IProjectRepository _ProjectRepository;
        public ProjectService(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }
        public async Task<(bool Success, string? Message)> CreateAsync(CreateProjectDto create)
        {
            try
            {
                Project project = new Project()
                {
                    Description = create.Description,
                    ShortDescription = create.ShortDescription,
                    Slug = create.Slug,
                    Title = create.Title,
                    UserId = 1
                };
                if (create.Thumbnail!=null && create.Thumbnail.Length >0)
                {
                    project.Thumbnail = await create.Thumbnail.SaveImage();
                }
                bool success = await _ProjectRepository.CreateAsync(project);
                if (success)
                {
                    return (true, "ثبت موفق !");
                }
                return (false, "ثبت ناموفق !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return (false, "خطا هنگام ذخیره سازی !"); ;
            }
        }

        public async Task<(bool Success, string? Message)> DeleteAsync(DeleteProjectDto delete)
        {
            var project = await _ProjectRepository.GetProject(delete.Id);
            FileService.DeleteImage(project.Thumbnail);
            bool success = await _ProjectRepository.DeleteAsync(project);

            if (!success)
            {
                return (false, "حذف شکست خورد");
            }
            return (true, "حذف موفق !");
        }

        public async Task<(ProjectDto? Projects, string? Message)> GetProject(int id)
        {
            if (id == null)
            {
                return (null, "کرم نریزید");
            }
            var entity = await _ProjectRepository.GetProject(id);
            ProjectDto projectDto = new ProjectDto()
            {
                Title = entity.Title,
                Description = entity.Description,
                Author = "علی مارتین",
                Id = entity.Id,
                ShortDescription = entity.ShortDescription,
                Slug = entity.Slug,
            };
            return (projectDto,null);
        }

        public async Task<(IEnumerable<ProjectDto> Projects, string? Message)> GetProjects()
        {
            var projects = await _ProjectRepository.GetProjectsAsync();
            List<ProjectDto> result = new List<ProjectDto>();
            foreach (var project in projects)
            {
                ProjectDto projectDto = new ProjectDto()
                {
                    Title = project.Title,
                    Description = project.Description,
                    Author = "علی مارتین",
                    Id = project.Id,
                    ShortDescription = project.ShortDescription,
                    Slug = project.Slug,
                };
                result.Add(projectDto);
            }
            return (result, null);
        }

        public async Task<(bool exists, string message)> IsExists(int id)
        {
            bool exists = await _ProjectRepository.IsExists(id);
            if (!exists)
            {
                return (exists, "نداریم آقا !");
            }
            return (exists, "موجوده آقا !");
        }

        public async Task<(bool Success, string? Message)> UpdateAsync(UpdateProjectDto update)
        {
            var (exists,message) = await IsExists(update.Id);
            if (!exists)
            {
                return (false, "نداریم آقا !");
            }
            var entity = await _ProjectRepository.GetProject(update.Id);
            entity.Title = update.Title;
            entity.Description = update.Description;
            entity.ShortDescription = update.ShortDescription;
            entity.Slug = update.Slug;
            if (update.Thumbnail != null && update.Thumbnail.Length > 0)
            {
                FileService.DeleteImage(entity.Thumbnail);
                entity.Thumbnail = await update.Thumbnail.SaveImage();
            }
            bool success = await _ProjectRepository.UpdateAsync(entity);
            if (!success)
            {
                return (success, "ویرایش نشد");
            }
            return (success, "ویرایش شد");
        }
    }
}
