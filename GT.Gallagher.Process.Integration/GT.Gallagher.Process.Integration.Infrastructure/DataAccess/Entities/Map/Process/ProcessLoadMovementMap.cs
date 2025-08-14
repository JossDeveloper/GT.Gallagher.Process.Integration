using CsvHelper.Configuration;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadMovement;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadMovementMap : ClassMap<ProcessLoadMovement>
{
    public ProcessLoadMovementMap()
    {
        Map(m => m.PolicyChannelCode).Index(0);
        Map(m => m.MovementNumber).Index(1);
        Map(m => m.MovementCode).Index(2);
        Map(m => m.FunctionaryCode).Index(3);
        Map(m => m.MovementDate).Index(4);
        Map(m => m.Comment).Index(5);
        Map(m => m.Support).Index(6);
    }
}
