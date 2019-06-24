using CnBlog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        public BaseRepository()
        {

        }

        public void Add(T aggregateRoot)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T aggregateRoot)
        {
            throw new NotImplementedException();
        }
    }
}
