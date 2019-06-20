using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentContext.test.Mocks;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Handler;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace paymentContext.test
{
    [TestClass]
    public class StudentQueriesTest
    {
        private IList<Students> _student; 

        public StudentQueriesTest()
        {
            for (int i = 0; i <= 10; i++)
            {
                _student.Add(new Students(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.cpf),
                    new Email(i.ToString() + "@teste.com"),
                    new Address("a", "10", "xz", "df", "gg", "br", "232556")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {   
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {   
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _student.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
       
    }
}