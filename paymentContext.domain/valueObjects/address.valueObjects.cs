using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObjectsShared
    {
        public Address(string street, string number, string neighborhood, string city, string state, string contry, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Contry = contry;
            ZipCode = zipCode;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(street, 5, "address.street", "O nome da rua deve conter pelo menos 5 caracteres")
            .HasMaxLen(street, 60, "address.street", "O nome da rua deve conter no máximo 60 caracteres")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Contry { get; private set; }
        public string ZipCode { get; private set; }
    }
    
}