﻿using AutoMapper;
using MediatR;
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
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
    {
        private readonly ILogger<CreatePostCommandHandler> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, ILogger<CreatePostCommandHandler> logger)
        {
            _logger = logger;
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var createPostCommandResponse = new CreatePostCommandResponse();
            var validation = new CreatePostCommandValidator();
            var validationResult = await validation.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createPostCommandResponse.Success = false;
                createPostCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createPostCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createPostCommandResponse.Success)
            {
                var post = new Post() { Content = request.Content };
                post = await _postRepository.AddAsync(post);
                createPostCommandResponse.Post = _mapper.Map<CreatePostDto>(post);
            }
            return createPostCommandResponse;
        }
    }
}