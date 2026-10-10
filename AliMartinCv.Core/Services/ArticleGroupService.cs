using AliMartinCv.Core.Entities;
using AliMartinCv.Core.Interfaces.Repositories;
using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.ArticleGroupViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Services
{
    public class ArticleGroupService : IArticleGroup
    {
        private readonly IArticleGroupRepository _repository;
        public ArticleGroupService(IArticleGroupRepository repository)
        {
            _repository = repository;
        }



        public async Task<(bool Success, string? Message)> CreateAsync(CreateArticleGroupDto create)
        {
            ArticleGroup articleGroup = new ArticleGroup()
            {
                Title = create.Title,
                ParentId = create.ParentId,
            };
            bool success = await _repository.CreateAsync(articleGroup);
            if (!success)
            {
                return (false, "عملیات با موفقیت شکست خورد !");

            }
            return (true, "ثبت با موفقیت انجام شد");

        }

        public async Task<(bool Success, string? Message)> DeleteAsync(DeleteArticleGroupDto delete)
        {
            ArticleGroup articleGroup = await _repository.GetArticleGroupAsync(delete.Id);
            if (articleGroup == null)
            {
                return (false, "شناسه یافت نشد");
            }
            bool success = await _repository.DeleteAsync(articleGroup);
            if (!success)
            {
                return (false, "عملیات با موفقیت شکست خورد");
            }
            return (true, "عملیات با موفقیت انجام شد");

        }

        public async Task<(ArticleGroupDto? articleGroup, string? Message)> GetArticleGroup(int id)
        {
            ArticleGroup articleGroup = await _repository.GetArticleGroupAsync(id);
            if (articleGroup == null)
            {
                return (null, "گروهی با این شناسه یافت نشد");
            }
            ArticleGroupDto articleGroupDto = new ArticleGroupDto()
            {
                Id = id,
                Title = articleGroup.Title,
                ParentId = articleGroup.ParentId,
                //TODO : Navigate Title
            };
            return (articleGroupDto, null);
        }

        public async Task<(IEnumerable<ArticleGroupDto> articleGroups, string? Message)> GetArticleGroups()
        {
           IEnumerable<ArticleGroup> articleGroups = await _repository.GetArticleGroupsAsync();
           List<ArticleGroupDto> articleGroupDtos = new List<ArticleGroupDto>();
            foreach (ArticleGroup articleGroup in articleGroups)
            {
                ArticleGroupDto articleGroupDto = new ArticleGroupDto()
                {
                    Id = articleGroup.Id,
                    Title = articleGroup.Title,
                    ParentId = articleGroup.ParentId,
                    //TODO : Navigate Title
                };
                articleGroupDtos.Add(articleGroupDto);
            }

            return (articleGroupDtos, null);
        }

        public async Task<(bool Success, string? Message)> UpdateAsync(UpdateArticleGroupDto update)
        {
            ArticleGroup articleGroup = new ArticleGroup()
            {
                Title = update.Title,
                Id = update.Id,
                ParentId = update.ParentId,
            };
            bool success = await _repository.UpdateAsync(articleGroup);
            if (!success)
            {
                return (false, "ویرایش با موفقیت شکست خورد");
            }
            return (true, "ویرایش موفقیت آمیز بود.");
        }
    }
}
