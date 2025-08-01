using Sarfati.Core.Enum;

namespace Sarfati.Core.Dto;

public class ChangeTaskStatusDto
{
    public int Status { get; set; }
    public long TaskId { get; set; }
    public string Image { get; set; }
}