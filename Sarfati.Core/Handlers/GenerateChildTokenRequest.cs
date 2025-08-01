using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GenerateChildTokenRequest : IRequest<GenerateChildTokenResponse>
    {
        public string ChildId { get; set; }
        public string ParentId { get; set; }
    }
}