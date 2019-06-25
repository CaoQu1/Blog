using CnBlog.Domain;
using CnBlog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CnBlog.Infrastructure.Repositories
{
    public class SystemUserRepository : BaseRepository<SystemUser, Guid>, ISystemUserRepository
    {
        private IRepository<Article, int> _articleRepository;

        public SystemUserRepository(IEFRepositoryContext eFRepositoryContext,
            IRepository<Article, int> articleRepository)
            : base(eFRepositoryContext)
        {
            this._articleRepository = articleRepository;
        }

        public List<UserArticle> GetUserArticle(Guid userGuid)
        {
            return this._articleRepository.GetAll().Where(x => x.CreateUserId == userGuid).Select(x => new UserArticle
            {

            }).ToList();
        }
    }
}
