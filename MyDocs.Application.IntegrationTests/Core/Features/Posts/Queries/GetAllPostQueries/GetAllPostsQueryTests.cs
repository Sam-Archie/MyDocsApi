using FluentAssertions;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests.Core.Features.Posts.Queries.GetAllPostQueries
{
    using static Testing;

    public class GetAllPostsQueryTests : TestBase
    {
        [Test]

        public async Task ShouldReturnAllPostsAndAssociatedData()
        {
            var userGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");
            await AddAsync(new User
            {
                Id = userGuid.ToString(),
                FirstName = "James",
                LastName = "Samson",
                Posts =
                {
                    new Post { 
                        Content = "Hello World", 
                        Title = "First ever line of code",
                        Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}") 
                    },
                    new Post { 
                        Content = "We will never ne rid of code, because code represents the datials of the requirements", 
                        Title = "Text from Clean Code",
                        Id = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}") 
                    },
                    new Post { 
                        Content = "The most exaggerated and memorable example I can give for what can occur when true intention of a font isn't fully understood by its users is the story of comic sans",
                        Title = "Text from Design for Hackers",
                        Id = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}"),
                }
            }
        });
        
            var query = new GetAllPostsQuery();

            var result = await SendAsync(query);

            result.Should().HaveCount(3);
            result.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
        }
    }
}
