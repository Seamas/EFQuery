using System;

namespace Seamas.EFQuery.Attributes;

public class NotEqualAttribute(string name = "" ) :QueryAttribute(name, SqlOperator.NotEqual)
{
    public override string ToExpression(int i, string propertyName)
    {
        return $"{GetPropertyName(propertyName)} <> @{i}";
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