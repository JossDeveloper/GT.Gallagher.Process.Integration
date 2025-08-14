using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace GT.Gallagher.Process.Integration.Domain.Helper;

public static class Util
{
    public static T GetAttributeOfType<T>(this System.Enum enumVal) where T : System.Attribute
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }

    public static string GetEnumMemberValue<T>(T value) where T : struct, IConvertible
    {
        return typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(x => x.Name == value.ToString())
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value;
    }

    public static T ToEnum<T>(string str)
    {
        var enumType = typeof(T);
        foreach (var name in System.Enum.GetNames(enumType))
        {
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            if (enumMemberAttribute.Value.ToUpper().Equals(str.ToUpper())) return (T)System.Enum.Parse(enumType, name, true);
        }
        return default;
    }

    public static string DateTimeToString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");

    public static DateTime StringToDateTime(this string date) => DateTime.ParseExact(date, "dd/mm/yyyy", CultureInfo.InvariantCulture);
}

