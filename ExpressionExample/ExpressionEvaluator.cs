using System;
using System.Collections.Generic;

namespace ExpressionExample
{
    internal class ExpressionEvaluator
    {
        List<MyExpression> _expressions;

        public ExpressionEvaluator()
        {
            _expressions = new List<MyExpression>();
            // These expressions and their results are clearly arbitrary - just to demonstrate what an expression might look like
            _expressions.Add(new MyExpression("C1 || (C2 && P1)", "Person Loves Peanut Butter"));
            _expressions.Add(new MyExpression("C3 && (P1 || P2) && (!C1 || P1)", "Person Loves Dancing"));
        }

        internal List<string> EvaluateExpressions(Dictionary<string, bool> ruleResults)
        {
            var results = new List<string>();

            Console.WriteLine("---- Here are the rule results:");
            foreach (var result in ruleResults)
                Console.WriteLine($"{result.Key} : {result.Value}");

            Console.WriteLine();
            Console.WriteLine();
            // This is where I am at a loss.
            // I have a list of expressions that are currently made up of just Rule IDs and logical operators.
            // I also have a bunch of rules that have been evaluated.
            // I need to turn my expression into something that can be evaluated, given these rule results.


            return results;
        }
    }
}