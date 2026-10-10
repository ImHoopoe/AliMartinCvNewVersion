using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.ArticleGroupViewModels
{
    public class CreateArticleGroupDto
    {
        public required string Title { get; set; }
        public int? ParentId { get; set; }
        public ICollection<ArticleGroupDto> ArticleGroups { get; set; } = new List<ArticleGroupDto>();
    }
}
