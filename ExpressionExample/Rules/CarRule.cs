using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionExample.Rules
{
    internal class CarRule : Rule
    {
        public CarRule(string ruleId, string property, ExpressionType op, object targetVal) :
            base(ruleId, property, op, targetVal)
        {
            
        }

        public override bool Evaluate(RelevantObject value)
        {
            var propertyValue = value.GetType().GetProperty(_property);

            if (propertyValue != null)
            {
                return ValueSatisfiesRule(propertyValue.GetValue(value));
            }

            return false;
        }
    }
}
