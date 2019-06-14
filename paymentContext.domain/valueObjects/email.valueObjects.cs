using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObjectsShared
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
            .Requires()
            .IsEmail(address, "Email.Address", "Email inválido")
            );
        }

        public string Address { get; private set; }
    }
}