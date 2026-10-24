using AliMartinCv.Core.ViewModels.Article;
using AliMartinCv.Core.ViewModels.Project;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Index
{
    public class IndexDto
    {
        public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
        public List<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
    }
}
