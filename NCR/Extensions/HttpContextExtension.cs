using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NCR.Extensions
{
    /// <summary>
    /// HttpContext 拓展类
    /// </summary>
    public static class HttpContextExtension
    {
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        public static string GetUserIp(this HttpContext context)
        {
            var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Connection.RemoteIpAddress.ToString();
            }
            return ip;
        }

        /// <summary>
        /// 转为日志内容
        /// </summary>
        public static async Task<string> ToLogString(this HttpRequest request, MemoryStream injectedRequestStream)
        {
            var requestStr = new StringBuilder();
            requestStr.AppendLine($"{request.Method} {request.GetAbsoluteUri()}");
            requestStr.AppendLine(request.GetHeaders());
            using (var bodyReader = new StreamReader(request.Body))
            {
                var bodyAsText = await bodyReader.ReadToEndAsync();
                if (bodyAsText.IsNotNullOrEmpty())
                {
                    var bytesToWrite = Encoding.UTF8.GetBytes(bodyAsText);
                    injectedRequestStream.Write(bytesToWrite, 0, bytesToWrite.Length);
                    injectedRequestStream.Seek(0, SeekOrigin.Begin);
                    request.Body = injectedRequestStream;
                    requestStr.AppendLine(bodyAsText);
                }
            }

            return requestStr.ToString();
        }

        /// <summary>
        /// 获取headers
        /// </summary>
        public static string GetHeaders(this HttpRequest request)
        {
            var writer = new StringWriter();
            foreach (var key in request.Headers.Keys)
            {
                writer.WriteLine("{0}: {1}", key, request.Headers[key]);
            }

            return writer.ToString();
        }

        public static string GetAbsoluteUri(this HttpRequest request)
        {
            return new StringBuilder()
                .Append(request.Scheme)
                .Append("://")
                .Append(request.Host)
                .Append(request.PathBase)
                .Append(request.Path)
                .Append(request.QueryString)
                .ToString();
        }
    }
}