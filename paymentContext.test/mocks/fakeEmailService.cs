using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;

namespace paymentContext.test.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string email, string subject, string body)
        {
            
        }
    }

}