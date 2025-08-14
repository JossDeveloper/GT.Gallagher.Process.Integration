using GT.Gallagher.Process.Integration.Domain.Validator.Process.LoadClient;

namespace GT.Gallagher.Process.Integration.Domain.Process.LoadClient;

public class ProcessLoadClient : Entity
{
    public string ClientCode { get; set; }
    public string PersonType { get; set; }
    public string DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string Name { get; set; }
    public string? LastName1 { get; set; }
    public string? LastName2 { get; set; }
    public string ContactPerson { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string ClientType { get; set; }
    public string? AccountManager { get; set; }
    public string? CollectionExecutive { get; set; }
    public string? AccidentExecutive { get; set; }
    public string? MarkContractor { get; set; }
    public string? MarkInsured { get; set; }
    public string? MarkResponsiblePayment { get; set; }
    public string? MarkAdditionalInsured { get; set; }
    public string? MarkInvoice { get; set; }
    public string? MarkEndorsee { get; set; }
    public string? MarkBeneficiary { get; set; }
    public string? ClientSegmentation { get; set; }

    public ProcessLoadClient(string clientCode, string personType, string documentType, string documentNumber, string name, string? lastName1, string? lastName2, string contactPerson, string phone, string address, string email, string clientType, string? accountManager, string? collectionExecutive, string? accidentExecutive, string? markContractor, string? markInsured, string? markResponsiblePayment, string? markAdditionalInsured, string? markInvoice, string? markEndorsee, string? markBeneficiary, string? clientSegmentation)
    {
        ClientCode = clientCode;
        PersonType = personType;
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        Name = name;
        LastName1 = lastName1;
        LastName2 = lastName2;
        ContactPerson = contactPerson;
        Phone = phone;
        Address = address;
        Email = email;
        ClientType = clientType;
        AccountManager = accountManager;
        CollectionExecutive = collectionExecutive;
        AccidentExecutive = accidentExecutive;
        MarkContractor = markContractor;
        MarkInsured = markInsured;
        MarkResponsiblePayment = markResponsiblePayment;
        MarkAdditionalInsured = markAdditionalInsured;
        MarkInvoice = markInvoice;
        MarkEndorsee = markEndorsee;
        MarkBeneficiary = markBeneficiary;
        ClientSegmentation = clientSegmentation;

        Validate(this, new ProcessLoadClientValidator());
    }
}
