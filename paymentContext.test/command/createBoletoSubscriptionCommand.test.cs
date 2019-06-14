using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;

namespace paymentContext.test
{
    [TestClass]
    public class createBoletoSubscriptionCommandtest
    {
        //red, green, refactory

        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.Valid);

        }
       
    }
}