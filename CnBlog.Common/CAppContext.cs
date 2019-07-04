using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnBlog.Common
{
    public class CAppContext
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceProvider ServiceProvider { get; set; }

        public static HttpContext HttpContext
        {
            get
            {
                if (ServiceProvider != null)
                {
                    return ((IHttpContextAccessor)ServiceProvider.GetService(typeof(IHttpContextAccessor))).HttpContext;
                }
                throw new ArgumentNullException("HttpContext is empty!");
            }
        }

        public static T GetService<T>()
        {
            return (T)HttpContext.RequestServices.GetService(typeof(T));
        }
    }
}
