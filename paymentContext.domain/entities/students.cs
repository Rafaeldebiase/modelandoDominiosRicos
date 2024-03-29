using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Students : Entity
    {

        private IList<Subscription> _subscription;

        public Students(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscription = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }        
        public IReadOnlyCollection<Subscription> Subscription { get { return _subscription.ToArray(); }}

        public void AddSubscription(Subscription subscription) {
            var hasSubscriptionActive = false;

            foreach (var sub in Subscription)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, 
                "Students.Subscription", 
                "Você já tem uma assinatura ativa"
                )
                .IsGreaterThan(0, subscription.Payments.Count,
                "Students.Payment.Subscription", "Esta assinatura não possuí pagamentos")
            );
        }
    }
}