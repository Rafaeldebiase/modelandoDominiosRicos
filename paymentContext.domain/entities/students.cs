using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }        
        public List<Subscription> Subscription { get; set; }
    }
}