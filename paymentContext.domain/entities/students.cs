using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Students
    {

        private IList<Subscription> _subscription;

        public Students(string firstName, string lastName, string document, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            Address = address;
            _subscription = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }        
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