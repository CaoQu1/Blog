using AutoMapper;
using CnBlog.Domain;
using CnBlog.Domain.Mappers;
using CnBlog.Domain.Model;

namespace CnBlog.Infrastructure.Mappers
{
    public class UserMapper : Profile, IProfile
    {
        public UserMapper()
        {
            this.CreateMap<Article, UserArticle>();
        }
    }
}
