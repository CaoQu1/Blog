using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Domain
{
    public interface IRepositoryContext
    {
        DbContext dbContext { get; }
    }
}
