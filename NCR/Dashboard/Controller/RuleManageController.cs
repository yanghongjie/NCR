﻿using System;
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
        public async Task<GetRuleListResponse> GetRuleList([FromBody]GetRuleListResquest request)
        {
            var response = new GetRuleListResponse();
            if (request.PageIndex <= 0)
            {
                request.PageIndex = 0;
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
        /// 新增规则
        /// </summary>
        [HttpPost("AddRule")]
        public async Task<AddRuleResponse> AddRule([FromBody]AddRuleRequest request)
        {
            var response = new AddRuleResponse();
            try
            {
                var rule = new Rule
                {
                    Name = request.Name,
                    Priority = request.Priority,
                    Type = request.Type,
                    Enabled = request.Enabled,
                    Desciption = request.Desciption
                };
                await _ruleRepository.AddRule(rule);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"AddRule 出现异常：{e.Message}", e);
            }
            return response;
        }

        /// <summary>
        /// 新增规则项目
        /// </summary>
        [HttpPost("AddRuleItem")]
        public async Task<AddRuleItemResponse> AddRuleItem([FromBody]AddRuleItemRequest request)
        {
            var response = new AddRuleItemResponse();
            try
            {
                var ruleItem = new RuleItem
                {
                    RuleId = request.RuleId,
                    RuleItemType = request.RuleItemType,
                    ComputeType = request.ComputeType,
                    Value = request.Value,
                    Enabled = request.Enabled,
                    Desciption = request.Desciption
                };
                await _ruleRepository.AddRuleItem(ruleItem);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError($"AddRuleItem 出现异常：{e.Message}", e);
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
                        Items = new List<RuleItem>
                        {
                            new RuleItem
                            {
                                RuleItemType = $"rule {i} test item",
                                ComputeType = BaseComputeType.Any.ToString(),
                                Value = random.Next(1,100).ToString(),
                            }
                        }
                    };
                    await _ruleRepository.AddRule(rule);
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