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
        public required int UserId { get; set; }
        #region Relations
        public required User Creator { get; set; }
        #endregion
    }
}
