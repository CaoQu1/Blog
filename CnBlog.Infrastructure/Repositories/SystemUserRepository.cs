using CnBlog.Domain;
using CnBlog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace CnBlog.Infrastructure.Repositories
{
    public class SystemUserRepository : BaseRepository<SystemUser, Guid>, ISystemUserRepository
    {
        private IRepository<Article, int> _articleRepository;
        private Mapper _mapper;

        public SystemUserRepository(IEFRepositoryContext eFRepositoryContext,
            IRepository<Article, int> articleRepository,
            Mapper mapper)
            : base(eFRepositoryContext)
        {
            this._articleRepository = articleRepository;
            this._mapper = mapper;
        }

        public List<UserArticle> GetUserArticle(Guid userGuid)
        {
            return Mapper.Map<List<UserArticle>>(this._articleRepository.GetAll().Where(x => x.CreateUserId == userGuid));
        }

        public void Init(List<SystemUser> systemUsers)
        {

        }
    }
}
