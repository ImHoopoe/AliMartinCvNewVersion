using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.ViewModels.Project
{
    public class DeleteProjectDto
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
    }
}
