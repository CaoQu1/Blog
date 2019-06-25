using CnBlog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CnBlog.Infrastructure.Repositories
{
    public class BaseRepository<T, F> : IRepository<T, F>
        where F : struct
        where T : class, IEntity<F>
    {
        protected readonly IEFRepositoryContext _repositoryContext;

        public BaseRepository(IEFRepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void Add(T aggregateRoot)
        {
            this._repositoryContext.AddAttach<T>(aggregateRoot);
        }

        public IQueryable<T> GetAll()
        {
            return this._repositoryContext.DbContext.Set<T>();
        }

        public void Update(T aggregateRoot)
        {
            this._repositoryContext.UpdateModify<T>(aggregateRoot);
        }
    }
}
