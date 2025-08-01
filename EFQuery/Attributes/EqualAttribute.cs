using System;

namespace Seamas.EFQuery.Attributes;

public class EqualAttribute(string name = "") : QueryAttribute(name, SqlOperator.Equal)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} == @{i}";
    }

    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            string str => !string.IsNullOrWhiteSpace(str),
            int i => i != 0,
            bool b => b,
            DateTime dt => dt != default,
            _ => true
        };
    }
}