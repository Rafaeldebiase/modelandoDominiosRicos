using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Students : Entity
    {

        private IList<Subscription> _subscription;

        public Students(name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;
            _subscription = new List<Subscription>();
        }

        public name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }        
        public IReadOnlyCollection<Subscription> Subscription { get { return _subscription.ToArray(); }}

        public void AddSubscription(Subscription subscription) {
            foreach (var sub in Subscription)
            {   
                sub.Inactivate();
            }

            _subscription.Add(subscription);
        }
    }
}