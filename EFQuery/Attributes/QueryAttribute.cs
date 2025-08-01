using System;

namespace Seamas.EFQuery.Attributes;


[AttributeUsage(AttributeTargets.Property)]
public abstract class QueryAttribute(string name, SqlOperator @operator) : Attribute
{
    public string PropertyName { get; protected set; } = name;
    
    public SqlOperator Operator { get; protected set; } = @operator;

    public abstract string ToExpression(int i, string propertyName);
    
    public abstract bool IsValid(object? value);
    
    protected string GetPropertyName(string propertyName)
    {
        return string.IsNullOrEmpty(PropertyName) ?  propertyName : PropertyName;
    }
    
    
}