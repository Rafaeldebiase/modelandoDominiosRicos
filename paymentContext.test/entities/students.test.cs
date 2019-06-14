using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;

namespace paymentContext.test
{
    [TestClass]
    public class StudentsTests
    {
        private readonly Students _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _adress;
        

        public StudentsTests()
        {
            _name = new Name ("Bruce", "Wayne");
            _document = new Document("63254397088", EDocumentType.cpf);
            _email = new Email("batmam@dc.com");
            _adress = new Address("Bat Caverna","69", "zona", "Gothan", "New York", "USA", "696969");
            _student = new Students(_name, _document, _email, _adress);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "wayne corp", _adress, _email);

            _subscription.AddPayment(payment);
            
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
        [TestMethod]
        public void ShouldReturnSucessWhenAddSubscription()
        {
            
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "wayne corp", _adress, _email);

            _subscription.AddPayment(payment);
            
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}