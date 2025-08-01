using System;
using System.Collections.Generic;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class AddTaskRequest : IRequest<bool>
    {
        public string Title { get; set; }
        public DateTime? Duration { get; set; }
        public string Description { get; set; }
        public List<Guid> FK_ChildId { get; set; }
        public string FK_ParentId { get; set; }
        public int Points { get; set; }
        public float Cash { get; set; }
        public string Avatar { get; set; }
        public string Image { get; set; }
        public bool IsRepeat { get; set; }
        public string Repetition { get; set; }
        public string Color { get; set; }
        public TaskType Type { get; set; }
    }
}