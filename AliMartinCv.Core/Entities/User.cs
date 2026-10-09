using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AliMartinCv.Core.Entities
{
    public class User
    {
        [Key]
        public required int Id { get; set;  }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }

        #region Relations

        public ICollection<Project> Projects { get; set; } = new List<Project>();
        #endregion
    }
}
