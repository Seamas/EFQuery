namespace Seamas.EFQuery.Attributes;

public class LikeAttribute(string name = "") : QueryAttribute(name, SqlOperator.Like)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)}.Contains(@{i})";
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            string strValue => !string.IsNullOrWhiteSpace(strValue),
            _ => false
        };
    }
}