using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace NCR.Dashboard.Middleware
{
    /// <summary>
    /// Net Core Rule Dashboard Middleware
    /// </summary>
    public static class NcrDashboardMiddleware
    {
        public static  void UseNcrDashboard(this IApplicationBuilder app, IConfiguration configuration)
        {
            //添加全局异常处理
            app.UseExceptionHandler("/globalerror");

            //添加请求响应日志
            app.UseRequestResponseLogging();
        }
    }
}