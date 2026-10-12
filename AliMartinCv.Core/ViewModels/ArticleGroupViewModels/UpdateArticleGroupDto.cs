using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.ViewModels.ArticleGroupViewModels
{
    public class UpdateArticleGroupDto
    {
        public required int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public int? ParentId { get; set; }
        public List<SelectListItem> ArticleGroups { get; set; } = new List<SelectListItem>();
    }
}
