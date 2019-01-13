namespace ExpressionExample
{
    public class PersonLovesDancingCondition : ICondition
    {
        public string ConditionName => "Person Loves Dancing";

        public bool Evaluate(RelevantObject model)
        {
            return model.CarYear > 2000;
        }
    }
}
