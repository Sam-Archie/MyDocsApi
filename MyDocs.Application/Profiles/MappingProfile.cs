using AutoMapper;
using MyDocs.Application.Features.Forums.Queries;
using MyDocs.Application.Features.Posts.Commands.CreatePost;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Domain.Entities;

namespace MyDocs.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostListVm>().ReverseMap();
            CreateMap<Post, CreatePostCommand>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Forum, ForumListVm>().ReverseMap();
        }
    }
}
