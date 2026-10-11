using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.ArticleGroupViewModels
{
    public class ArticleGroupDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ParentTitle { get; set; }
        public int? ParentId { get; set; }

    }
}
