using System.Runtime.Serialization;

namespace GT.Gallagher.Process.Integration.Domain.Enum;

public enum RecordType
{
    [EnumMember(Value = "Start")]
    Start,
    [EnumMember(Value = "InputValidation")] //01
    InputValidation,
    [EnumMember(Value = "BusinessRule")] //02
    BusinessRule,
    [EnumMember(Value = "GetInformation")] //03
    GetInformation,
    [EnumMember(Value = "SetInformation")] //04
    SetInformation,
    [EnumMember(Value = "ConsumeService")] //05
    ConsumeService,
    [EnumMember(Value = "InternalBuild")] //06
    InternalBuild,
    [EnumMember(Value = "InternalService")] //07
    InternalService,
    [EnumMember(Value = "GetSftpFiles")] //08
    GetSftpFiles,
    [EnumMember(Value = "PutSftpFiles")] //09
    PutSftpFiles,
    [EnumMember(Value = "End")]
    End,
    [EnumMember(Value = "Error")]
    Error,
}

