namespace Seamas.EFQuery.Attributes;

public class StartsWithAttribute(string name = "") : QueryAttribute(name, SqlOperator.StartsWith)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)}.StartsWith(@{i})";
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            string strValue => !string.IsNullOrEmpty(strValue),
            _ => false
        };
    }
}