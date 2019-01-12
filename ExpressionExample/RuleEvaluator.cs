using ExpressionExample.Rules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ExpressionExample
{
    internal class RuleEvaluator
    {
        private List<Rule> _rules;

        public RuleEvaluator()
        {
            _rules = new List<Rule>();
            _rules.Add(new CarRule("C1", "CarMake", ExpressionType.Equal, "Honda"));
            _rules.Add(new CarRule("C2", "CarYear", ExpressionType.GreaterThan, 2000));
            _rules.Add(new CarRule("C3", "CarMake", ExpressionType.NotEqual, "Toyota"));
            _rules.Add(new PersonRule("P1", "FirstName", ExpressionType.Equal, "Nick"));
            _rules.Add(new PersonRule("P2", "FavoriteColor", ExpressionType.NotEqual, "Red"));
        }

        /// <summary>
        /// Given an instance of a RelevantObject, evaluate all of the rules we know about
        /// </summary>
        /// <param name="relevantObject">Object containing data to evaluate</param>
        /// <returns>Key=RuleId, Value=Result of evaluating the rule</returns>
        internal Dictionary<string, bool> EvaluateRules(RelevantObject relevantObject)
        {
            var results = new Dictionary<string, bool>();

            foreach (Rule rule in _rules)
            {
                bool result = rule.Evaluate(relevantObject);
                results[rule.RuleId] = result;
                Console.WriteLine($"Result of rule [{rule}] is [{result}] for object: {Environment.NewLine}\t\t[{relevantObject}]");
            }
            
            return results;
        }
    }
}