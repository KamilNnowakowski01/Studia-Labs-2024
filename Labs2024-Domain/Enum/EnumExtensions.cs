using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        ?.GetName();
    }

    public static T GetValueFromDisplayName<T>(string displayName) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            var attribute = field.GetCustomAttribute<DisplayAttribute>();
            if (attribute != null && attribute.Name == displayName)
            {
                return (T)field.GetValue(null);
            }
        }

        throw new ArgumentException($"Not found: {displayName}", nameof(displayName));
    }
}
