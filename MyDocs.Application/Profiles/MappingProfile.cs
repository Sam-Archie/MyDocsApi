using AutoMapper;
using MyDocs.Application.Features.Forums.Commands.CreateForum;
using MyDocs.Application.Features.Forums.Queries.GetAllForums;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Application.Features.Posts.Queries.GetPostById;
using MyDocs.Domain.Entities;

namespace MyDocs.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostListVm>().ReverseMap();
            CreateMap<Post, PostVm>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Forum, ForumListVm>().ReverseMap();
            CreateMap<Forum, CreateForumCommand>().ReverseMap();
        }
    }
}
