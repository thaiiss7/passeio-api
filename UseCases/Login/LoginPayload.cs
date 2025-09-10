using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace Passeio.UseCases.Login;

public record LoginPayload
{
    [Required]
    [MaxLength(256)]
    public required string Login { get; init; }
    [Required]
    [MaxLength(256)]
    public required string Password { get; init; }
};