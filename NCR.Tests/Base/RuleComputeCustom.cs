using System;
using NCR.Internal;

namespace NCR.Tests.Base
{
    public class RuleComputeCustom : RuleCompute
    {
        private readonly IDataAccess _dataAccess;

        public RuleComputeCustom(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        protected override bool CustomCompute(string computeType, string ruleValue, string factValue)
        {
            ruleValue = ruleValue.ToLower();
            factValue = factValue.ToLower();
            switch (computeType)
            {
                case "ExistsBySql":
                    return CheckExistsBySql(ruleValue, factValue);
                case "NotExistsBySql":
                    return !CheckExistsBySql(ruleValue, factValue);
                default:
                    throw new ArgumentOutOfRangeException(nameof(computeType), computeType, $"{computeType} 找不到对应的运算方法。");
            }
        }

        private bool CheckExistsBySql(string sql,string checkValue)
        {
            var ret = 0;
            sql = sql.ToUpper();
            //过滤数据库关键字
            if (sql.Contains("INSERT ") ||
                sql.Contains("UPDATE ") ||
                sql.Contains("DELETE ") ||
                sql.Contains("TRUNCATE ") ||
                sql.Contains("DROP ") ||
                sql.Contains("ALTER "))
            {
                return false;
            }
            //只有查询语句才生效
            if (sql.StartsWith("SELECT"))
            {
                var param = new
                {
                    CheckValue = checkValue
                };
                ret = _dataAccess.ExecuteNonQuery(sql, param);
            }

            return ret > 0;
        }
    }
}