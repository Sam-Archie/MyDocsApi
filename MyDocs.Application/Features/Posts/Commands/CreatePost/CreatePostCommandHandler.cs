using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyDocs.Application.Contracts.Persistance;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CreatePostCommandHandler> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, ILogger<CreatePostCommandHandler> logger, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validation = new CreatePostCommandValidator(_postRepository);
            var validationResult = await validation.ValidateAsync(request);
            var currentUser = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var post = new Post()
            {
                UserId = currentUser.Id,
                Title = request.Title,
                Content = request.Content
            };

            post = _mapper.Map<Post>(request);

            post = await _postRepository.AddAsync(post);

            return post.Id;
           }
        }
    }

