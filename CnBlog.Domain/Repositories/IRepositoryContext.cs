using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Domain
{

    public interface IDbContext
    {
        EntityEntry<T> Entry<T>(T model) where T : class;

        DbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }

    public interface IRepositoryContext
    {
        bool IsCommit { get; set; }

        bool Commit();

        void Rollback();
    }

    public interface IEFRepositoryContext : IRepositoryContext
    {
        IDbContext DbContext { get; }

        void AddAttach<T>(T model) where T : class;

        void UpdateModify<T>(T model) where T : class;
    }
}
