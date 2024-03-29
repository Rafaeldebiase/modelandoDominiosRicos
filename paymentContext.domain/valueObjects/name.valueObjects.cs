using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObjectsShared
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(firstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
            .HasMinLen(lastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
            .HasMaxLen(firstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caracteres")
            .HasMaxLen(lastName, 40, "Name.LastName", "Sobrenome deve conter no máximo 40 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}