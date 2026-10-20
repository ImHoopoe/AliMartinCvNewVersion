using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ShortDescription { get; set; }
        public required string Description { get; set; }
        public required string Slug { get; set; }
        public int UserId { get; set; }
        public string? Thumbnail { get; set; } = "project.png";
        #region Relations
        public User Creator { get; set; }
        #endregion
    }
}
