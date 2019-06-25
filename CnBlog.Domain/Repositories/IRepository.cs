using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CnBlog.Domain
{
    public interface IRepository<T, F>
        where F : struct
        where T : class, IEntity<F>
    {
        void Add(T aggregateRoot);

        IQueryable<T> GetAll();

        void Update(T aggregateRoot);
    }
}
