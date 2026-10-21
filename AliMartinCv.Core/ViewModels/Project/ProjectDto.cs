using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Project
{
    public class ProjectDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string ShortDescription { get; set; }
        public required string Description { get; set; }
        public required string Slug { get; set; }
        public required string Author { get; set; }
        public required string Thumbnail { get; set; }

    }
}
