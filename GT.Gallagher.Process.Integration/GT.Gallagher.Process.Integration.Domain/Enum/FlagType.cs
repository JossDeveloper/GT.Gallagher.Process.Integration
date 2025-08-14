using System.Runtime.Serialization;

namespace GT.Gallagher.Process.Integration.Domain.Enum;

public enum FlagType
{
    [EnumMember(Value = "S")]
    S,
    [EnumMember(Value = "N")]
    N,
}

