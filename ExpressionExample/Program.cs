using System;
using System.Collections.Generic;

namespace ExpressionExample
{
    class Program
    {
        private static IList<ICondition> conditions = new List<ICondition>();
        static void Main(string[] args)
        {
            // these are your rules. 
            // instead of a string like C1 || (C2 && P1), 
            // you will have these object combined together            
            conditions.Add(new PersonLovesPeanutButterCondition());
            conditions.Add(new PersonLovesDancingCondition());

            // here you ll have your list of models from db
            var models = GetRelevantObjects();

            foreach (var model in models)
            {
                // go through the conditions to find the one that is right
                EvaluateConditions(model);
            }
        }

        private static void EvaluateConditions(RelevantObject model)
        {
            foreach (var condition in conditions)
            {
                var result = condition.Evaluate(model);
                if (result)
                {
                    var conditionType = condition.ConditionName;
                    // do something with the result
                }
            }
        }

        static List<RelevantObject> GetRelevantObjects()
        {
            return new List<RelevantObject>
            {
                new RelevantObject
                {                   
                    Id = Guid.Parse("48c49b48-90d5-4e82-b727-ad04e14ffaca"),
                    CarMake = "Honda",
                    CarYear = 2004,
                    PersonData = new Dictionary<string, string> { {"FirstName", "Nick" }, {"FavoriteColor", "Orange"} }
                },
                new RelevantObject
                {
                    Id = Guid.Parse("a40e87c0-4ead-4f34-b5b4-5d784ee721d5"),
                    CarMake = "Toyota",
                    CarYear = 2009,
                    PersonData = new Dictionary<string, string> { {"FirstName", "Paul" }, {"FavoriteColor", "Red"} }
                },
                new RelevantObject
                {
                    Id = Guid.Parse("701f97bf-a70f-49bd-b86c-e0e4e13e051e"),
                    CarMake = "Subaru",
                    CarYear = 1999,
                    PersonData = new Dictionary<string, string> { {"FirstName", "Sarah" }, {"FavoriteColor", "Blue"} }
                }
            };
        }
    }
}
