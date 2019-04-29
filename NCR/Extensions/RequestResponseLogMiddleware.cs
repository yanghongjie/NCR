using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using NCR.Extensions;

namespace NCR.Extensions
{
    /// <summary>
    /// 请求响应日志中间件
    /// </summary>
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        /// <summary>
        /// 构造函数
        /// </summary>
        public RequestResponseLogMiddleware(RequestDelegate next,ILogger<RequestResponseLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// 执行
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            var injectedRequestStream = new MemoryStream();
            try
            {
                if (!context.Request.Path.Value.Contains("swagger") && !context.Request.Path.Value.Contains("warmup"))
                {
                    var requestLog = new StringBuilder();
                    requestLog.Append($"{Environment.NewLine}【Req_{context.TraceIdentifier.Replace(":", "")}】{Environment.NewLine}");
                    requestLog.Append($"IP：{context.GetUserIp() + Environment.NewLine}");
                    requestLog.Append($"{await context.Request.ToLogString(injectedRequestStream)}");
                    _logger.LogInformation(requestLog.ToString());

                    EnableReadResponseBodyAsync(context.Response);

                    context.Response.OnCompleted(async o =>
                    {
                        if (o is HttpContext c)
                        {
                            var retStr = await ReadResponseBodyAsync(c.Response);
                            var responseLog = new StringBuilder();
                            responseLog.Append($"{Environment.NewLine}【Res_{context.TraceIdentifier.Replace(":", "")}】" + Environment.NewLine);
                            responseLog.Append($"{(retStr.IsNotNullOrEmpty() ? retStr + Environment.NewLine : string.Empty)}");
                            responseLog.Append("--------------------------------------------------------------------");

                            _logger.LogInformation(responseLog.ToString());
                        }
                    }, context);
                }

                await _next.Invoke(context);
            }
            finally
            {
                injectedRequestStream.Dispose();
            }
        }

        #region 获取ResponseBody

        private async Task<string> ReadResponseBodyAsync(HttpResponse response)
        {
            if (response.Body.Length > 0)
            {
                //var position = response.Body.Position;
                response.Body.Seek(0, SeekOrigin.Begin);
                var encoding = this.GetEncoding(response.ContentType);
                var retStr = await ReadStreamAsync(response.Body, encoding, false).ConfigureAwait(false);

                return retStr;
            }
            return null;
        }

        private Encoding GetEncoding(string contentType)
        {
            var mediaType = contentType == null ? default(MediaType) : new MediaType(contentType);
            var encoding = mediaType.Encoding;
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding;
        }

        private void EnableReadResponseBodyAsync(HttpResponse response)
        {
            if (!response.Body.CanRead || !response.Body.CanSeek)
            {
                response.Body = new MemoryWrappedHttpResponseStream(response.Body);
            }
        }

        private async Task<string> ReadStreamAsync(Stream stream, Encoding encoding, bool forceSeekBeginZero = true)
        {
            using (var sr = new StreamReader(stream, encoding, true, 1024, true))//这里注意Body部分不能随StreamReader一起释放
            {
                var str = await sr.ReadToEndAsync();
                if (forceSeekBeginZero)
                {
                    stream.Seek(0, SeekOrigin.Begin);//内容读取完成后需要将当前位置初始化，否则后面的InputFormatter会无法读取
                }
                return str;
            }
        }

        #endregion
    }

    sealed class MemoryWrappedHttpResponseStream : MemoryStream
    {
        private readonly Stream _innerStream;
        public MemoryWrappedHttpResponseStream(Stream innerStream)
        {
            this._innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
        }
        public override void Flush()
        {
            this._innerStream.Flush();
            base.Flush();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
            this._innerStream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this._innerStream.Dispose();
            }
        }

        public override void Close()
        {
            base.Close();
            this._innerStream.Close();
        }
    }

    /// <summary>
    /// 请求响应日志中间件拓展方法
    /// </summary>
    public static class RequestResponseLoggingMiddlewareExtensions
    {
        /// <summary>
        /// 使用 请求响应日志中间件
        /// </summary>
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestResponseLogMiddleware>();
        }
    }
}