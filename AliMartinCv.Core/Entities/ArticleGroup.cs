using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.Entities
{
    public class ArticleGroup
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public int? ParentId { get; set; }

        #region Relations
        public ArticleGroup? Parent { get; set; }
        public ICollection<Article>? Articles { get; set; }
        #endregion

    }
}
