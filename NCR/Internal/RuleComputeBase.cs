using System;
using System.Linq;
using System.Text.RegularExpressions;
using NCR.Enums;
using NCR.Extensions;
using NCR.Models;

namespace NCR.Internal
{
    public class RuleComputeBase : RuleCompute
    {
        protected override bool CustomCompute(string computeType, string ruleValue, string factValue)
        {
            throw new NotImplementedException();
        }
    }
}
