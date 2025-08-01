using Microsoft.AspNetCore.Http;

namespace Sarfati.Core.Dto;

public class UploadImageDto
{
    public IFormFile Image { get; set; }
    public long Id { get; set; }
}