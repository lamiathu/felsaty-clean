using System;
using System.Collections.Generic;
using Sarfati.Core.Dto;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class GetParentTasksResponse
    {
        public List<TaskWithChildren> Tasks { get; set; }
    }

    public class TaskWithChildren
    {
        // Task Information
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? Duration { get; set; }
        public string Description { get; set; }
        public Guid FK_ParentId { get; set; }
        public int Points { get; set; }
        public float Cash { get; set; }
        public string Avatar { get; set; }
        public string Color { get; set; }
        public bool IsRepeat { get; set; }
        public RepeatDto Repetition { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskType Type { get; set; }
        
        public string TaskImage { get; set; }

        // Calculated task status based on children
        public Enums Status { get; set; }

        // Children assigned to this task
        public List<TaskChildInfo> Children { get; set; }
    }

    public class TaskChildInfo
    {
        public long TaskChildId { get; set; }
        public Guid ChildId { get; set; }
        public string ChildName { get; set; }
        public string ChildAvatar { get; set; }
        public Enums Status { get; set; }
        public string Notes { get; set; }
        public string ChildTaskImage { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    //old
    public class TaskModalChild
    {
        public long Id { get; set; }
        public long TaskChildId { get; set; }
        public string ChildName { get; set; }
        public string ChildAvatar { get; set; }
        public string Title { get; set; }
        public DateTime? Duration { get; set; }
        public string Description { get; set; }
        public Enums Status { get; set; }
        public long FK_ImageId { get; set; }
        
        public long TaskImageId { get; set; }
        public int Points { get; set; }
        public string Avatar { get; set; }
        public string Color { get; set; }
        public string Notes { get; set; }
        public bool IsRepeat { get; set; }
        public RepeatDto Repetition { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskType Type { get; set; }
    }
}