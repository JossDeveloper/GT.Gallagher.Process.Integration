using AutoMapper;
using GT.Gallagher.Process.Integration.Application.Repository.Records;
using GT.Gallagher.Process.Integration.Domain.Records;
using GT.Gallagher.Process.Integration.Infrastructure.Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

using Ent = GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Records;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Repositories.Records;

public class RecordRepository : IRecordRepository
{
    private readonly IMapper _mapper;

    public RecordRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public void Add(Record record, List<StepRecord> stepRecords)
    {
        using (var context = new Context())
        {
            var entityRecord = _mapper.Map<Ent.Record>(record);
            var entityStepRecord = _mapper.Map<List<Ent.StepRecord>>(stepRecords);

            var parameter = new List<SqlParameter>();
                parameter.Add(new SqlParameter() { SqlDbType = SqlDbType.Structured, ParameterName = "@Record", TypeName = "dbo.Record", Value = Util.ToDataTable(entityRecord) });
                parameter.Add(new SqlParameter() { SqlDbType = SqlDbType.Structured, ParameterName = "@StepRecord", TypeName = "dbo.StepRecord", Value = Util.ListToDataTable(entityStepRecord) });

            context.Database.ExecuteSqlRaw(@"exec SW_Save_Records @Record, @StepRecord", parameter.ToArray());
        }
    }
}
