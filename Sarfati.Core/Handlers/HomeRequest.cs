using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class HomeRequest : IRequest<HomeResponse>
    {
        public string DeviceId { get; set; }
        public bool Subscribe { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
    }
}