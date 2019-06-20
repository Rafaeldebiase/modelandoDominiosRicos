using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Students, bool>> GetStudentInfo(String document)
        {
            return x => x.Document.Number == document;
        }
    }

}