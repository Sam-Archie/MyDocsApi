using FluentAssertions;
using MyDocs.Application.Features.Forums.Queries;
using MyDocs.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests.Core.Features.Forums.Queries
{
    using static Testing;

    public class GetAllPostsQueryTests : TestBase
    {


        [Test]
        
        public async Task ShouldReturnAllPostsAndAssociatedData()
        {
            var Head_HonchoId = Guid.NewGuid().ToString();
            var BeerManId = Guid.NewGuid().ToString();
            var HairManId = Guid.NewGuid().ToString();


            await AddAsync(
                new Forum
                {
                    Name = "Marsala Dreams",
                    IsPrivate = false,
                    ForumId = Guid.NewGuid(),
                    Posts =
                    {
                        new Post
                        {
                            UserId = BeerManId,
                            Title = "Beer is no match",
                            Content = "Now I have tasted the sweet nectar of Marsala I will never dring a beer again!"
                        },
                        new Post
                        {
                            UserId = Head_HonchoId,
                            Title = "The World Of Sweetness",
                            Content = "Marsala is literally the greatest thing in the world",
                        }
                    },
                    User =
                        {
                            new User
                            {
                                Id = Head_HonchoId,
                                FirstName = "Ben",
                                LastName = "Wallace",
                                UserName = "Head_Honcho",
                            },
                            new User
                            {
                                Id = BeerManId,
                                FirstName = "John",
                                LastName = "Smith",
                                UserName = "Beer_Man",
                            },
                            new User
                            {
                                Id = HairManId,
                                FirstName = "Pete",
                                LastName = "Dee",
                                UserName = "Hair_Man",
                            }
                        }
                });

            var query = new GetAllForumsQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
        }
    }
}
