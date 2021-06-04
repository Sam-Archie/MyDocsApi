using FluentAssertions;
using MyDocs.Application.Exceptions;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Domain.Entities;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests.Core.Features.Posts.Commands.Posts
{
    using static Testing;

    public class CreatePostTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreatePostCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreatePost()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreatePostCommand
            {
                UserId = Guid.Parse(userId),
                Title = "Notes from HTML & CSS",
                Content = "Links are the defining feature of the web because they allow you to move from one page to another"
            };


            var response = await SendAsync(command);

            var post = await FindAsync<Post>(response);

            post.Should().NotBeNull();
            post.UserId.Should().Be(command.UserId.ToString());
            post.Content.Should().Be(command.Content);
        }
    }
}
