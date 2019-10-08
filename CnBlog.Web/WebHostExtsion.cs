using AutoMapper;
using AutoMapper.Configuration;
using CnBlog.Domain.Mappers;
using CnBlog.Infrastructure.Repositories;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CnBlog.Web
{
    public static class WebHostExtsion
    {
        public static IWebHost DataBaseInit<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seed) where TContext : BlogContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var logger = serviceProvider.GetRequiredService<TraceSource>();
                var context = serviceProvider.GetRequiredService<TContext>();
                try
                {
                    context.Database.Migrate();
                    seed(context, serviceProvider);
                    logger.TraceEvent(TraceEventType.Information, 1, "初始化成功!");
                }
                catch (Exception ex)
                {
                    logger.TraceEvent(TraceEventType.Error, 2, ex.Message);
                }
            }
            return webHost;
        }

        public static void UserInit(BlogContext blogContext, IServiceProvider serviceProvider)
        {
            if (!blogContext.SystemUsers.Any())
            {
                var user = blogContext.SystemUsers.Add(new Domain.SystemUser
                {
                    Actvar = "11@11",
                    UserName = "caoqu",
                    RealName = "caoqu",
                    Mobile = "15196613744",
                    PassWord = "123456",
                    Signature = "111",
                    Email = ""
                });
                blogContext.SaveChanges();

                var category = blogContext.ArticleCategories.Add(new Domain.ArticleCategory
                {
                    CategoryName = "分类",
                    CategoryNo = "111",
                    CreateUserId = user.Entity.Id,
                    CreateTime = DateTime.Now,
                    Remark = "备注"
                });
                blogContext.SaveChanges();

                blogContext.Articles.Add(new Domain.Article
                {
                    Author = "caoqu",
                    Content = "测试内容",
                    CategoryId = category.Entity.Id,
                    CreateUserId = user.Entity.Id,
                    CreateTime = DateTime.Now
                });

                blogContext.SaveChanges();
            }
        }
    }

    public static class AppBuilder
    {
        public static IApplicationBuilder UseMapper(this IApplicationBuilder applicationBuilder)
        {
            var allType = Assembly.GetEntryAssembly()
                .GetReferencedAssemblies()
               .Select(Assembly.Load)
               .SelectMany(y => y.DefinedTypes)
               .Where(t => typeof(IProfile).GetTypeInfo().IsAssignableFrom(t.AsType()));

            MapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();
            foreach (var item in allType)
            {
                var type = item.AsType();
                if (!type.IsInterface && !type.IsAbstract && typeof(IProfile).IsAssignableFrom(type))
                {
                    mapperConfigurationExpression.AddProfile(type);
                }
            }
            Mapper.Initialize(mapperConfigurationExpression);
            return applicationBuilder;
        }
    }
}
