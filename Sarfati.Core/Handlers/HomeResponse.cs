using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class HomeResponse
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}