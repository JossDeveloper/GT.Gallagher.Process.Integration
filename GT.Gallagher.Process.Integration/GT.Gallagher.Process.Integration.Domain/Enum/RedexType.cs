using System.ComponentModel;
using System.Runtime.Serialization;

namespace GT.Gallagher.Process.Integration.Domain.Enum;

public enum RedexType
{
    [EnumMember(Value = @"^[A-Za-zÑñáéíóúÁÉÍÓÚ0-9. ]+$")]
    [Description("El campo no debe estar vacío, no permite caracteres que no sea números y letras")]
    NOVACIO,

    [EnumMember(Value = @"^[0-9]+$")]
    [Description("El campo permite solo números")]
    NUMERO,

    [EnumMember(Value = @"^[A-Za-z][A-Za-z]*$")]
    [Description("El campo permite solo letras")]
    LETRA,

    [EnumMember(Value = @"^[a-zA-Z0-9]+$")]
    [Description("El campo permite solo números y letras")]
    NUMEROYLETRA,

    [EnumMember(Value = @"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))")]
    [Description("El campo no cumple el formato de fecha yyyy-mm-dd, donde 'yyyy' son los 4 dígitos del año, 'mm' son los 2 dígitos del mes y 'dd' son los 2 dígitos del día")]
    FECHA,

    [EnumMember(Value = @"((?:[12]\d{3}-(?:0[1-9]|1[0-2])-(?:0[1-9]|[12]\d|3[01]))|(?:[12]\d{3}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])))")]
    [Description("El campo no cumple el formato de fecha yyyyMMdd, donde 'yyyy' son los 4 dígitos del año, 'MM' son los 2 dígitos del mes y 'dd' son los 2 dígitos del día")]
    FECHASTRING,

    [EnumMember(Value = @"^(([0-9]{1,7}))(\.\d{0,2})*$")]
    [Description("El campo permite números enteros ó [7 Enteros . 2 Decimales]")]
    NUMERODECIMAL,

    [EnumMember(Value = @"^(\w+[\w-\.-_&#*$+'''']*\@\w+((-\w+)|(\w*))(\.[\w]{2,5})+)$")]
    [Description("El campo no cumple el formato de email válido")]
    EMAIL,

    [EnumMember(Value = @"^\d{6,12}$")]
    [Description("El campo no cumple el formato de teléfono válido")]
    TELEFONO,

    [EnumMember(Value = @"^(?!0)9[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]?$")]
    [Description("El campo no cumple el formato de celular válido")]
    CELULAR,

    [EnumMember(Value = @"^\d\d\/\d{4}$")]
    [Description("El campo no cumple el formato de fecha mm/yyyy, donde 'mm' son los 2 dígitos del mes, y 'yyyy' son los 4 dígitos del año")]
    FECHA_TJT
}


