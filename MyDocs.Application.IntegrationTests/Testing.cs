using MediatR;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {

        }

        public static async Task AddAsync<TEntity>(TEntity entitiy) where TEntity : class
        {

        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {

        }
    }
}
