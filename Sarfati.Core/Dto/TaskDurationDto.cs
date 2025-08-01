using System;
using System.Collections.Generic;

namespace Sarfati.Core.Dto;

public class TaskDurationDto
{
    public long id { get; set; }
    public string CreatedAt { get; set; }

    public DateTime Duration { get; set; }
}