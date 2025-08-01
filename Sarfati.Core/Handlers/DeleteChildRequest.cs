using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class DeleteChildRequest : IRequest<bool>
    {
        public string ChildId { get; set; }
    }
}