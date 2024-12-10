using System.ComponentModel;
using System.Reflection;

namespace FormsIW5.Common.Enums;

public static class EnumExtensions
{
    public static string GetReadableName(this Enum enumValue)
    {
        return enumValue.ToString();
    }
}
