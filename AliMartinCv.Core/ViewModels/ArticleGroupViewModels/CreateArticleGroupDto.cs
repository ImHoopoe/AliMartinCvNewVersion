using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.ViewModels.ArticleGroupViewModels
{
    public class CreateArticleGroupDto
    {
        [Required]
        public string Title { get; set; }

        public int? ParentId { get; set; }

        [ValidateNever]
        public List<SelectListItem> ArticleGroups { get; set; } = new();
    }
}
