using FluentAssertions;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
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

    public class CreatePostTests : TestBase
    {
        [Test]
        public async Task ShouldCreatePost()
        {
            var userId = Guid.NewGuid().ToString();

            var command = new CreatePostCommand
            {
                UserId = Guid.Parse(userId),
                Title = "Notes from HTML & CSS",
                Content = "Links are the defining feature of the web because they allow you to move from one page to another"
            };

            var response = await SendAsync(command);

            var postDto = await FindAsync<Post>(response.Post.PostId);

            postDto.Should().NotBeNull();
            postDto.User.Id.Should().Be(command.UserId.ToString());
            postDto.Content.Should().Be(command.Content);


        }
    }
}
