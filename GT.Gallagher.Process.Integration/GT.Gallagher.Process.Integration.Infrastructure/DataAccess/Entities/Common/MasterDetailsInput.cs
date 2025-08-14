using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Common;

public class MasterDetailsInput
{
    public int RowNumber { get; private set; }
    public string TextString { get; private set; }
    public string Details { get; private set; }
    public bool Status { get; private set; }

    public MasterDetailsInput(int rowNumber, object value, List<ProblemDetail> details)
    {
        RowNumber = rowNumber;
        TextString = JsonConvert.SerializeObject(value);
        Details = JsonConvert.SerializeObject(details);
        Status = !details.Any(s => !s.Message.IsNullOrEmpty());
    }
}
