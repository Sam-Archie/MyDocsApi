using MediatR;
using MyDocs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Application.Features.Forums.Queries
{
    public class GetAllForumsQuery : IRequest<List<Forum>>
    {
    }
}
