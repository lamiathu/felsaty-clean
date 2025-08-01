using System;
using System.Collections.Generic;

namespace Sarfati.Core.Dto;

public class TaskRepetitionDto
{
    public long id { get; set; }
    
    public string CreatedAt { get; set; }
    
    public string IsRepeat { get; set; }
    public string Repetition { get; set; }
    
    public string RepetitionStartTime { get; set; }
}

public class RepeatDto
{
    public List<string> Days { get; set; }
    public TimeSpan? StartTime { get; set; }
}