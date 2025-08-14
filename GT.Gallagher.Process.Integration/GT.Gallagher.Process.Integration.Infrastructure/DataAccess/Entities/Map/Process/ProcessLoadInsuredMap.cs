using CsvHelper.Configuration;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadInsured;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadInsuredMap : ClassMap<ProcessLoadInsured>
{
    public ProcessLoadInsuredMap()
    {
        Map(m => m.PolicyChannelCode).Index(0);
        Map(m => m.ClientCode).Index(1);
        Map(m => m.PersonType).Index(2);
    }
}
