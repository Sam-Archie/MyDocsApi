using MyDocs.Application.Features.Posts.Commands.CreatePost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests.Core.Features.Posts.Commands.Posts
{
    using static Testing;

    public class CreatePostTests
    {
        [Test]

        public async Task ShouldCreatePost()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreatePostCommand
            {

            };
        }
    }
}
