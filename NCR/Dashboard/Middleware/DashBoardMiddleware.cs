using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using NCR.Extensions;


namespace NCR.Dashboard.Middleware
{
    /// <summary>
    /// Net Core Rule DashBoard Middleware
    /// </summary>
    public class DashboardMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// 构造函数
        /// </summary>
        public DashboardMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await Task.FromResult("Hello");
        }
    }

    public static class DashboardMiddlewareExtensions
    {
        public static void UseNcrDashboard(this IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var path = context.Request.Path.Value;

                if (path.StartsWith("/ncr"))
                {
                    if (path == "/ncr")
                    {
                        context.Response.Redirect("/ncr/");
                        return;
                    }

                    path = path.Replace("/ncr", "").TrimStart('/');
                    if (path.IsNullOrEmpty())
                    {
                        path = "index.html";
                    }
                    string htmlStr;
                    var currentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dashboard", "Dist", path);
                    using (var fs = new FileStream(currentPath, FileMode.Open, FileAccess.Read))
                    {
                        using (var sr = new StreamReader(fs, Encoding.UTF8))
                        {
                            htmlStr = sr.ReadToEnd();
                        }
                    }
                    await context.Response.WriteAsync(htmlStr);
                }
            });
        }
    }
}