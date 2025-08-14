using CsvHelper.Configuration;
using GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Process.LoadClient;

namespace GT.Gallagher.Process.Integration.Infrastructure.DataAccess.Entities.Map.Process;

public class ProcessLoadClientMap : ClassMap<ProcessLoadClient>
{
    public ProcessLoadClientMap()
    {
        Map(m => m.ClientCode).Index(0);
        Map(m => m.PersonType).Index(1);
        Map(m => m.DocumentType).Index(2);
        Map(m => m.DocumentNumber).Index(3);
        Map(m => m.Name).Index(4);
        Map(m => m.LastName1).Index(5);
        Map(m => m.LastName2).Index(6);
        Map(m => m.ContactPerson).Index(7);
        Map(m => m.Phone).Index(8);
        Map(m => m.Address).Index(9);
        Map(m => m.Email).Index(10);
        Map(m => m.ClientType).Index(11);
        Map(m => m.AccountManager).Index(12);
        Map(m => m.CollectionExecutive).Index(13);
        Map(m => m.AccidentExecutive).Index(14);
        Map(m => m.MarkContractor).Index(15);
        Map(m => m.MarkInsured).Index(16);
        Map(m => m.MarkResponsiblePayment).Index(17);
        Map(m => m.MarkAdditionalInsured).Index(18);
        Map(m => m.MarkInvoice).Index(19);
        Map(m => m.MarkEndorsee).Index(20);
        Map(m => m.MarkBeneficiary).Index(21);
        Map(m => m.ClientSegmentation).Index(22);
    }
}
