namespace Seamas.EFQuery.Attributes;

public class IsNotNullAttribute(string name = "") : QueryAttribute(name, SqlOperator.IsNotNull)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} != null";    
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            string str => !string.IsNullOrWhiteSpace(str),
            _ => true
        };
    }
}