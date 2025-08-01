using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GenerateChildTokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}