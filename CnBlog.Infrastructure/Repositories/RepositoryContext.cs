using CnBlog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Infrastructure.Repositories
{
    public class EFRepositoryContext : IEFRepositoryContext
    {
        public IDbContext DbContext { get; }

        public EFRepositoryContext(IDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public bool IsCommit { get; set; } = false;

        public void AddAttach<T>(T model) where T : class
        {
            var entity = this.DbContext.Entry<T>(model);
            entity.State = EntityState.Added;
            this.Commit();
        }

        public bool Commit()
        {
            try
            {
                if (IsCommit)
                {
                    this.DbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                IsCommit = false;
                return false;
            }
        }

        public void Rollback()
        {
            IsCommit = false;
        }

        public void UpdateModify<T>(T model) where T : class
        {
            var entity = this.DbContext.Entry<T>(model);
            entity.State = EntityState.Modified;
            this.Commit();
        }
    }
}
