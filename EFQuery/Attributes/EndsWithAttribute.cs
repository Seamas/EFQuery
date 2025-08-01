namespace Seamas.EFQuery.Attributes;

public class EndsWithAttribute(string name = "") : QueryAttribute(name, SqlOperator.EndsWith)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)}.EndsWith(@{i})";
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