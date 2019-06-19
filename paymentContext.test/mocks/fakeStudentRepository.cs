using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace paymentContext.test.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Students students)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if (document == "12345678910") {
                return true;
            }

            return false;
        }

        public bool EmailExists(string email)
        {
           if (email == "rafael@teste.com") {
               return true;
           }

           return false;
        }
    }

}