using CnBlog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Domain
{
    public interface ISystemUserRepository : IRepository<SystemUser, Guid>
    {
        List<UserArticle> GetUserArticle(Guid userGuid);
    }
}
