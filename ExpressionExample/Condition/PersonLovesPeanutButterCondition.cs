namespace ExpressionExample
{
    public class PersonLovesPeanutButterCondition : ICondition
    {
        public string ConditionName => "Person Loves Peanut Butter";

        public bool Evaluate(RelevantObject model)
        {
            // your whole logic comes here
            // C1 || (C2 && P1)
            return model.CarMake == "Honda";
        }
    }
}
