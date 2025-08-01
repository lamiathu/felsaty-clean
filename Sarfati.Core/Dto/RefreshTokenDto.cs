using System;

namespace Sarfati.Core.Dto;

public class RefreshTokenDto
{
    public string RefreshToken { get; set; }
    public DateTime ExpiresAt { get; set; }
}