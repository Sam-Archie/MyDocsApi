using MediatR;
using System.Collections.Generic;

namespace MyDocs.Application.Features.Forums.Queries.GetAllForums
{
    public class GetAllForumsQuery : IRequest<List<ForumListVm>>
    {

    }
}
