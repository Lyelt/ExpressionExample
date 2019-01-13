namespace ExpressionExample
{
    public interface ICondition
    {
        string ConditionName { get; }
        bool Evaluate(RelevantObject model);
    }
}
