using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class AddChildRequest : IRequest<AddChildResponse>
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ParentId { get; set; }
        public string Gender { get; set; }
        
        public string Color { get; set; }  
        public string Avatar { get; set; }
    }
}