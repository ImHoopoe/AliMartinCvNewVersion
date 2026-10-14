using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Article
{
    public class DeleteArticleDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
    }
}
