using System.ComponentModel.DataAnnotations;

namespace Passeio.UseCases.CreateTour;

public record CreateTourPayload
{
    [Required]
    [MaxLength(20)]
    public required string Title { get; init; }
    [Required]
    [MinLength(40)]
    [MaxLength(200)]
    public required string Bio { get; init; }
}
