using FluentAssertions;
using MyDocs.Application.Features.Forums.Commands.CreateForum;
using MyDocs.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.IntegrationTests.Core.Features.Forums.Commands
{
    using static Testing;

    public class CreateForumTest : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateForumCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<Exceptions.ValidationException>();
        }

        [Test]
        public async Task ShouldCreateForum()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateForumCommand
            {
                OwnerId = Guid.Parse(userId),
                IsPrivate = false,
                Name = "Burgundy Brigade"
            };


            var response = await SendAsync(command);

            var forum = await FindAsync<Forum>(response);

            forum.Should().NotBeNull();
            forum.OwnerId.Should().Be(command.OwnerId);
            forum.Name.Should().Be(command.Name);
        }
    }
}
