using GT.Gallagher.Process.Integration.Domain.Records;

namespace GT.Gallagher.Process.Integration.Application.Repository.Records;

public interface IRecordRepository
{
    void Add(Record record, List<StepRecord> stepRecords);
}
