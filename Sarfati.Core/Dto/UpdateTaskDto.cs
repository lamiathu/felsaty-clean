using System;
using System.Collections.Generic;

namespace Sarfati.Core.Dto;

public class UpdateTaskDto
{
    public long TaskId { get; set; }
    public string? Title { get; set; }
    public DateTime? Duration { get; set; }
    public string? Description { get; set; }
    public List<Guid>? RemoveChildIds { get; set; }
    public int? Points { get; set; }
    public float? Cash { get; set; }
    public string? Avatar { get; set; }
    public string? Color { get; set; }
    public string Image { get; set; }
    public bool? IsRepeat { get; set; }
    public RepeatDto? Repetition { get; set; }
    public int? TaskType { get; set; }
}