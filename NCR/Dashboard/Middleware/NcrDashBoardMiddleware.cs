using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace NCR.Dashboard.Middleware
{
    /// <summary>
    /// Net Core Rule DashBoard Middleware
    /// </summary>
    public static class NcrDashBoardMiddleware
    {
        /// <summary>
        /// 使用 Net Core Rule
        /// </summary>
        public static  void UseNcrDashboard(this IApplicationBuilder app, IConfiguration configuration)
        {
   
        }
    }
}