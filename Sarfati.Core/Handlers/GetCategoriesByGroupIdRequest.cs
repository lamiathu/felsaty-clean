using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GetCategoriesByGroupIdRequest : IRequest<GetCategoriesByGroupIdResponse>
    {
        public int GroupId { get; set; }
        public int PageNumber { get; set; }

    }
}