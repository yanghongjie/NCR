using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NCR.Dashboard.Model;

namespace NCR.Dashboard.Controller
{
    /// <summary>
    /// 公用接口
    /// </summary>
    [Route("")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ILogger _logger;

        public CommonController(ILogger<CommonController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 点火地址
        /// </summary>
        [HttpGet("warmup")]
        public async Task<string> Warmup()
        {
            return await Task.FromResult("ok");
        }

        /// <summary>
        /// 当前服务器信息
        /// </summary>
        [HttpGet("info")]
        public IActionResult Info()
        {
            var envList = Environment.GetEnvironmentVariables();
            envList.Add("ServerTime", DateTime.Now);
            envList.Add("ProcessorCount", Environment.ProcessorCount);

            return new JsonResult(envList);
        }

        /// <summary>
        /// 全局错误处理
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("globalerror")]
        public BaseResponse GlobalError()
        {
            var fe = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var error = fe?.Error;
            _logger.LogError($"系统异常：{error?.Message}", error);

            var res = new BaseResponse
            {
                Code = ErrorCode.内部服务异常,
                Message = error?.Message
            };

            return res;
        }
    }
}