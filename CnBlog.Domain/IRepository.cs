using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Domain
{
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T aggregateRoot);

        IEnumerable<T> GetAll();

        void Update(T aggregateRoot);
    }
}
