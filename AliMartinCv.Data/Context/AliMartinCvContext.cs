using AliMartinCv.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Data.Context
{
    public class AliMartinCvContext : DbContext
    {
        public AliMartinCvContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
