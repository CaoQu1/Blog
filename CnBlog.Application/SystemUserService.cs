using CnBlog.Common;
using CnBlog.Domain;
using CnBlog.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Application
{
    public class SystemUserService
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDbContext, BlogContext>(option =>
             {
                 option.UseSqlServer(configuration.GetConnectionString("Blog"));
             });
            services.TryAddTransient<IEFRepositoryContext, EFRepositoryContext>();
            services.TryAddTransient(typeof(IRepository<,>), typeof(BaseRepository<,>));
            services.TryAddTransient<ISystemUserRepository, SystemUserRepository>();
            services.TryAddSingleton<SystemUserService, SystemUserService>();
        }


        public static SystemUserService Instance
        {
            get { return CAppContext.GetService<SystemUserService>(); }
        }

        private readonly ISystemUserRepository _systemUserRepository;

        public SystemUserService(ISystemUserRepository systemUserRepository)
        {
            this._systemUserRepository = systemUserRepository;
        }

    }
}
