using FluentAssertions;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Application.Features.Posts.Commands.DeletePost;
using MyDocs.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests.Core.Features.Posts.Commands.Posts
{
    using static Testing;

    public class DeletePostTest : TestBase
    {
        [Test]
        public async Task ShouldDeletePost()
        {
            var userId = await RunAsDefaultUserAsync();
            {
            var command = new CreatePostCommand
            {
                UserId = Guid.Parse(userId),
                Title = "Help",
                Content = "I am to be deleted!!!"
            };

            var response = await SendAsync(command);

            var post = await FindAsync<Post>(response);

                await SendAsync(new DeletePostCommand
                {
                    Id = post.Id
                });

            var deletedPost = await FindAsync<Post>(post.Id);

            deletedPost.Should().BeNull();
            }
        }
    }
}
