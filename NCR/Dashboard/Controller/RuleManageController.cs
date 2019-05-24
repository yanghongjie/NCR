using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NCR.Dashboard.Model;
using NCR.Enums;
using NCR.Models;

namespace NCR.Dashboard.Controller
{
    /// <summary>
    /// 公用接口
    /// </summary>
    [Route("RuleManage")]
    [ApiController]
    public class RuleManageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRuleRepository _ruleRepository;

        public RuleManageController(ILogger<RuleManageController> logger, IRuleRepository ruleRepository)
        {
            _logger = logger;
            _ruleRepository = ruleRepository;
        }

        /// <summary>
        /// 获取规则集合
        /// </summary>
        [HttpPost("GetRuleList")]
        public async Task<GetRuleListResponse> GetRuleList([FromBody]GetRuleListRequest request)
        {
            var response = new GetRuleListResponse();
            if (request.PageIndex <= 1)
            {
                request.PageIndex = 0;
            }
            else
            {
                request.PageIndex = request.PageIndex - 1;
            }
            if (request.PageSize < 20)
            {
                request.PageSize = 20;
            }
            try
            {
                response = await _ruleRepository.GetRules(request);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"GetRuleList 出现异常：{e.Message}", e);
            }
            return response;
        }

        /// <summary>
        /// 保存规则
        /// </summary>
        [HttpPost("SaveRule")]
        public async Task<SaveRuleResponse> SaveRule([FromBody]SaveRuleRequest request)
        {
            var response = new SaveRuleResponse();
            try
            {
                var rule = new Rule
                {
                    Id = request.Id,
                    Name = request.Name,
                    Priority = request.Priority,
                    Type = request.Type,
                    Enabled = request.Enabled,
                    Desciption = request.Desciption
                };
                await _ruleRepository.SaveRule(rule);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"SaveRule 出现异常：{e.Message}", e);
            }
            return response;
        }

        /// <summary>
        /// 保存规则项目
        /// </summary>
        [HttpPost("SaveRuleItem")]
        public async Task<SaveRuleItemResponse> SaveRuleItem([FromBody]SaveRuleItemRequest request)
        {
            var response = new SaveRuleItemResponse();
            try
            {
                var ruleItem = new RuleItem
                {
                    Id = request.Id,
                    RuleId = request.RuleId,
                    RuleItemType = request.RuleItemType,
                    ComputeType = request.ComputeType,
                    Value = request.Value,
                    Enabled = request.Enabled,
                    Desciption = request.Desciption
                };
                await _ruleRepository.SaveRuleItem(ruleItem);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"SaveRuleItem 出现异常：{e.Message}", e);
            }
            return response;
        }

        /// <summary>
        /// 根据规则编号获取规则
        /// </summary>
        [HttpPost("GetRuleById")]
        public async Task<GetRuleByIdResponse> GetRuleById([FromBody]GetRuleByIdRequest request)
        {
            var response = new GetRuleByIdResponse();
           
            try
            {
                response.Data = await _ruleRepository.GetRuleById(request.RuleId);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"GetRuleById 出现异常：{e.Message}", e);
            }
            return response;
        }

        /// <summary>
        /// 初始化测试数据
        /// </summary>
        [HttpPost("InitFakeData")]
        public async Task<BaseResponse> InitFakeData(int dataCount)
        {
            var response = new BaseResponse();
            try
            {
                var random = new Random();
                for (int i = 1; i <= dataCount; i++)
                {
                    var rule = new Rule
                    {
                        Name = $"test rule {i}",
                        Priority = i,
                        Desciption = $"test rule {i} desc",
                        Items = new List<RuleItem>
                        {
                            new RuleItem
                            {
                                RuleItemType = $"rule {i} test item",
                                ComputeType = BaseComputeType.Any.ToString(),
                                Value = random.Next(1,100).ToString(),
                                Desciption = $"rule {i} test item desc",
                            }
                        }
                    };
                    if (i > 6)
                    {
                        rule.Enabled = false;
                    }
                    await _ruleRepository.SaveRule(rule);
                }
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"AddRuleItem 出现异常：{e.Message}", e);
            }
            return response;
        }
    }
}