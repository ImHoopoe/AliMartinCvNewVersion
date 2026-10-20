using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Project
{
    public class CreateProjectDto
    {
        public required string Title { get; set; }
        public required string ShortDescription { get; set; }
        public required string Description { get; set; }
        public required string Slug { get; set; }
        public IFormFile? Thumbnail { get; set; }
    }
}
