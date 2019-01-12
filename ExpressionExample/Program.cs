using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RuleEvaluator ruleEval = new RuleEvaluator();
            ExpressionEvaluator expressionEval = new ExpressionEvaluator();

            foreach (var relevantObject in GetRelevantObjects())
            {
                Dictionary<string, bool> ruleResults = ruleEval.EvaluateRules(relevantObject);
                Console.WriteLine("---- Rules Have Been Evaluated ----");
                List<string> categoryResults = expressionEval.EvaluateExpressions(ruleResults);
            }

            Console.ReadKey();
        }

        static List<RelevantObject> GetRelevantObjects()
        {
            return new List<RelevantObject>
            {
                new RelevantObject
                {
                    CarMake = "Honda",
                    CarYear = 2004,
                    PersonData = new Dictionary<string, string> { {"FirstName", "Nick" }, {"FavoriteColor", "Orange"} }
                },
                new RelevantObject
                {
                    CarMake = "Toyota",
                    CarYear = 2009,
                    PersonData = new Dictionary<string, string> { {"FirstName", "Paul" }, {"FavoriteColor", "Red"} }
                },
                new RelevantObject
                {
                    CarMake = "Subaru",
                    CarYear = 1999,
                    PersonData = new Dictionary<string, string> { {"FirstName", "Sarah" }, {"FavoriteColor", "Blue"} }
                }
            };
        }
    }
}
