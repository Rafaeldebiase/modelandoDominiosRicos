using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;

namespace paymentContext.test
{
    [TestClass]
    public class DocumentTest
    {
        //red, green, refactory

        [TestMethod]
        public void ShouldReturnErrorWhenCnpjIsInvalid()
        {
            var doc = new Document("123", EDocumentType.cnpj);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSucessWhenCnpjIsValid()
        {
            var doc = new Document("45811370000147", EDocumentType.cnpj);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenCpfIsInvalid()
        {
            var doc = new Document("123", EDocumentType.cpf);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSucessWhenCpfIsValid()
        {
            var doc = new Document("67393882027", EDocumentType.cpf);
            Assert.IsTrue(doc.Valid);
        }
    }
}