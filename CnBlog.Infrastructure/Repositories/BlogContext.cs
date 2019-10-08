using CnBlog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Infrastructure.Repositories
{
    public class BlogContext : DbContext, IDbContext
    {
        public BlogContext() : base()
        {

        }

        public BlogContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<SystemUser> SystemUsers { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
