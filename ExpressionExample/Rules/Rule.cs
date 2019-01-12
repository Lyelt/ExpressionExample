using System;
using System.Linq.Expressions;

namespace ExpressionExample.Rules
{
    internal abstract class Rule
    {
        public string RuleId { get; private set; }

        protected string _property;
        protected object _targetValue;
        protected Expression _target;
        protected ExpressionType _operator;

        public Rule(string ruleId, string property, ExpressionType op, object targetVal)
        {
            RuleId = ruleId;
            _property = property;
            _operator = op;
            _targetValue = targetVal;
            _target = Expression.Constant(targetVal);
        }

        protected bool ValueSatisfiesRule(object val)
        {
            Expression left = Expression.Constant(val);
            BinaryExpression binary = Expression.MakeBinary(_operator, left, _target);
            Func<bool> evaluateRule = Expression.Lambda<Func<bool>>(binary).Compile();

            return evaluateRule(); // At this point I could also return the Expression itself
        }

        public override string ToString()
        {
            return $"{_property} {_operator} {_targetValue}";
        }

        public abstract bool Evaluate(RelevantObject value);
    }
}
