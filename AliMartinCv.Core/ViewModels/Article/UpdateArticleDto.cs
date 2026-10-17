using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Article
{
    public class UpdateArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IFormFile? Thumbnail { get; set; }
        public string Tags { get; set; }
        public int ArticleGroupId { get; set; }
        public required List<SelectListItem> ArticleGroups = new List<SelectListItem>();
    }
}
