using System.Collections;

namespace Seamas.EFQuery.Attributes;

public class InAttribute(string name = "") : QueryAttribute(name, SqlOperator.In)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} in @{i}";    
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            IEnumerable enumerable => enumerable.GetEnumerator().MoveNext(),
            _ => false
        };
    }
}