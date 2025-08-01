using System;
using System.Collections.Generic;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers;

public class UpdateTaskRequest : IRequest<bool>
{
    
    public long TaskId { get; set; }
    
    public string? Title { get; set; }
    
    public DateTime? Duration { get; set; }
    
    public string? Description { get; set; }
    
    public List<Guid>? RemoveChildIds { get; set; }
    
    public int? Points { get; set; }
    
    public float? Cash { get; set; }
    
    public string? Avatar { get; set; }
    
    public string Image { get; set; }
    
    public bool? IsRepeat { get; set; }
    
    public string? Repetition { get; set; }
    
    public string? Color { get; set; }
    
    public int? Type { get; set; }
}