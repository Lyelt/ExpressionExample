using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
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

        internal void EvaluateExpressions(Dictionary<string, bool> ruleResults)
        {
            Console.WriteLine("---- Here are the rule results:");
            foreach (var result in ruleResults)
                Console.WriteLine($"{result.Key} : {result.Value}");

            Console.WriteLine();
            Console.WriteLine();
            foreach (var expression in _expressions)
            {
                try
                {
                    Script script = null;

                    foreach (var rr in ruleResults)
                    {
                        if (script == null)
                            script = CSharpScript.Create<bool>(CreateBooleanVariable(rr.Key, rr.Value));
                        else
                            script = script.ContinueWith(CreateBooleanVariable(rr.Key, rr.Value));
                    }

                    script = script.ContinueWith(expression.ExpressionString);
                    var result = script.RunAsync().Result;

                    Console.WriteLine($"Following script was run: [{result.Script.Code}].");
                    Console.WriteLine($"Expression [{expression.ExpressionString}] result is [{result.ReturnValue}]. Therefore: [{((bool)result.ReturnValue ? expression.ResultString : "result not relevant")}]");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
            }
        }

        private string CreateBooleanVariable(string variableName, bool value)
        {
            return $"bool {variableName} = {value.ToString().ToLower()};";
        }
    }
}