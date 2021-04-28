using AutoMapper;
using MyDocs.Application.Features.Posts.Queries.GetAllPostsQuery;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostListVm>().ReverseMap();
        }
    }
}
