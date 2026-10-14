using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Article
{
    public class ArticleDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Slug { get; set; }
        public required string ShortDescription { get; set; }
        public required string Description { get; set; }
        public required string Thumbnail { get; set; } = "Thumbnail.png";
        public required string[] Tags { get; set; }
        public required string PublishDate { get; set; }
        public string? LastUpdate { get; set; } = "ویرایش ندارد";
        public required string Author { get; set; } = "ادمین سایت";
        public required string ArticleGroup { get; set; }
    }
}
