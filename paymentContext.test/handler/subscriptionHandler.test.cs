using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentContext.test.Mocks;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Handler;
using PaymentContext.Domain.ValueObjects;

namespace paymentContext.test
{
    [TestClass]
    public class SubscriptionHandlerTest
    {
        //red, green, refactory

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
           var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
           var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "bruce";
            command.LastName = "waine";
            command.Document = "12345678910";
            command.email = "rafael@teste.com2";
            command.BarCode = "12345871";
            command.BoletoNumber = "526262626";
            command.PaymentNumber = "965262626251";
            command.PaidDate = DateTime.Now;       
            command.ExpireDate = DateTime.Now.AddMonths(1);    
            command.Total = 60;
            command.TotalPaid = 60;
            command.PayerDocument = "wayne corp";
            command.PayerDocumentType = EDocumentType.cpf;
            command.Payer = "12345678911";
            command.Street = "batcaverna";
            command.Number = "22662";
            command.Neighborhood = "bla";
            command.City = "dfv";
            command.State = "eff";
            command.Contry = "fvbf";
            command.ZipCode = "fdb";
            command.PayerEmail = "batman@dc.com";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
       
    }
}