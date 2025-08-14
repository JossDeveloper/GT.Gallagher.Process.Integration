using System.Runtime.Serialization;

namespace GT.Gallagher.Process.Integration.Domain.Enum;

public enum AttachedType
{
    [EnumMember(Value = ".pdf")]
    pdf,
    [EnumMember(Value = ".xlsx")]
    xlsx,
    [EnumMember(Value = ".csv")]
    csv,
    [EnumMember(Value = ".txt")]
    txt
}
