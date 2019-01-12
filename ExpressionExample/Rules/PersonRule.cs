using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionExample.Rules
{
    internal class PersonRule : Rule
    {
        public PersonRule(string ruleId, string property, ExpressionType op, object targetVal) :
            base(ruleId, property, op, targetVal)
        {

        }

        public override bool Evaluate(RelevantObject value)
        {
            if (value.PersonData.TryGetValue(_property, out string data))
                return ValueSatisfiesRule(data);

            return false;
        }
    }
}
