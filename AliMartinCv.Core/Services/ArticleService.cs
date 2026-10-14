using AliMartinCv.Core.Entities;
using AliMartinCv.Core.Interfaces.Repositories;
using AliMartinCv.Core.Interfaces.Service;
using AliMartinCv.Core.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AliMartinCv.Core.Services
{
    public class ArticleService : IArticle
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<(bool Success, string? Message)> CreateAsync(CreateArticleDto create)
        {
            Article article = new Article()
            {
                Author = "مدیر سایت",
                ArticleGroupId = create.ArticleGroupId,
                Description = create.Description,
                PublishDate = DateTimeOffset.UtcNow,
                LastUpdate = DateTimeOffset.UtcNow,
                ShortDescription = create.ShortDescription,
                Slug = create.Slug,
                Tags = create.Tags,
                Title = create.Title,
                //TODO : Save Image

            };
            bool success = await _articleRepository.CreateAsync(article);
            if (!success)
            {
                return (false, "ذخیره سازی با موفقیت شکست خورد !");
            }
            return (true, "ذخیره سازی با موفقیت انجام شد !");
        }

        public async Task<(bool Success, string? Message)> DeleteAsync(DeleteArticleDto delete)
        {
            bool exists = await _articleRepository.IsExists(delete.Id);
            if (!exists)
            {
                return (false, "مقاله یافت نشد");
            }
            var article = await _articleRepository.GetArticleAsync(delete.Id);
            bool success = await _articleRepository.DeleteAsync(article);
            if (!success)
            {
                return (false, "حذف با موفقیت شکست خورد !");
            }
            return (true, "حذف شد.");
        }

        public async Task<(ArticleDto? article, string? Message)> GetArticle(int id)
        {
            bool exists = await _articleRepository.IsExists(id);
            if (!exists)
            {
                return (null, "مقاله یافت نشد");
            }
            var article = await _articleRepository.GetArticleAsync(id);
            if (article == null)
            {
                return (null, "پردازش با خطا مواجه شد");
            }
            ArticleDto articleDto = new ArticleDto()
            {
                Id = article.Id,
                ArticleGroup = article.ArticleGroup.Title,
                Author = article.Author,
                Description = article.Description,
                PublishDate = article.PublishDate.ToString(),
                //ToDo : Convert To Shmsi
                ShortDescription = article.ShortDescription,
                Slug = article.Slug,
                Tags = article.Tags.Split(','),
                Thumbnail = article.Thumbnail,
                Title = article.Title,
                LastUpdate = article.LastUpdate.ToString(),
                //ToDo : Convert To Shmsi
            };
            return (articleDto, null);
        }

        public async Task<(IEnumerable<ArticleDto> article, string? Message)> GetArticles(int? pageNumber = 1, int? skip = 10)
        {
            var articles = await _articleRepository.GetArticlesAsync();
            int split = pageNumber.Value - 1;
            skip = skip.Value * split;

            articles = articles.Skip(skip.Value).Take(10);
            var articlesDto = new List<ArticleDto>();
            foreach (var article in articles)
            {
                ArticleDto articleDto = new ArticleDto()
                {
                    Id = article.Id,
                    ArticleGroup = article.ArticleGroup.Title,
                    Author = article.Author,
                    Description = article.Description,
                    PublishDate = article.PublishDate.ToString(),
                    ShortDescription = article.ShortDescription,
                    Slug = article.Slug,
                    Tags = article.Tags.Split(","),
                    Thumbnail = article.Thumbnail,
                    Title = article.Title,
                    LastUpdate = article.LastUpdate.ToString(),
                };
                articlesDto.Add(articleDto);
            }
            return (articlesDto, null);
        }

        public async Task<(bool exists, string message)> IsExists(int id)
        {
            var result = await _articleRepository.IsExists(id);
            if (!result)
            {
                return (false, "مقاله یافت نیافت");
            }
            return (true,null);
        }

        public async Task<(bool Success, string? Message)> UpdateAsync(UpdateArticleDto update)
        {
            bool exists = await _articleRepository.IsExists(update.Id);
            if (!exists)
            {
                return (false, "مقاله ناموجود");
            }
            var article = await _articleRepository.GetArticleAsync(update.Id);
            article.Title = update.Title;
            article.Slug = update.Slug;
            article.Author = "ادمین سایت";
            article.Description = update.Description;
            article.ShortDescription = update.ShortDescription;
            article.ArticleGroupId = update.ArticleGroupId;
            article.LastUpdate = DateTimeOffset.Now;
            bool success = await _articleRepository.UpdateAsync(article);
            if (!success)
            {
                return (false, "ویرایش با موفقیت شکست خورد !");
            }
            return (true, "تغییرات ذخیره شد");
        }
    }
}
