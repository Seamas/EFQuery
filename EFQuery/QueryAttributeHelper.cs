using System.Linq;
using System.Reflection;
using Seamas.EFQuery.Attributes;

namespace Seamas.EFQuery;

public static class QueryAttributeHelper
{
    public static (string, object?[] param) Visit(object obj)
    {
        var propertyInfos = obj.GetType().GetProperties()
            .Where(p => p.GetCustomAttribute<QueryAttribute>() != null)
            .ToArray();

        var sql = " true ";
        var param = new object?[propertyInfos.Length];
        
        for (var i = 0; i < propertyInfos.Length; i++)
        {
            var propertyInfo = propertyInfos[i];
            var queryAttribute = propertyInfo.GetCustomAttribute<QueryAttribute>();

            var value = propertyInfo.GetValue(obj);
            param[i] = value;
            
            // If the value is not valid, we skip adding it to the SQL query.
            // This allows for dynamic filtering based on the attributes.
            if (queryAttribute.IsValid(value))
            {
                sql += $" and {queryAttribute.ToExpression(i, propertyInfo.Name)} ";
            }

        }

        return (sql, param);
    }
}