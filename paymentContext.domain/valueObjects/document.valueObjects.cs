using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObjectsShared
    {
        public Document(string munber, EDocumentType type)
        {
            Munber = munber;
            Type = type;
        }

        public string Munber { get; private set; }
        public EDocumentType Type { get; private set; }
    }
    
}