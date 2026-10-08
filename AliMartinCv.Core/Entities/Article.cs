using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.Entities
{
    public class Article
    {
        [Key]
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Slug { get; set; }
        public required string ShortDescription { get; set; }
        public required string Description { get; set; }
        public required string Thumbnail { get; set; } = "Thumbnail.png";
        public required string Tags { get; set; }
        public required DateTimeOffset PublishDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? LastUpdate { get; set; }
        public required string Author { get; set; } = "ادمین سایت";


        #region Relations
        public required int ArticleGroupId { get; set; }
        public required ArticleGroup ArticleGroup { get; set; }
        #endregion
    }
}
