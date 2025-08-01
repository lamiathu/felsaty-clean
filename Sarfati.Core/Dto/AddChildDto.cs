using System;

namespace Sarfati.Core.Dto
{
    public class AddChildDto
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        
        public string Color { get; set; }  
        public string Avatar { get; set; }
    }
}