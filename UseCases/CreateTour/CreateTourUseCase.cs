using Passeio.Models;
using Passeio.Services.Tour;

namespace Passeio.UseCases.CreateTour;

public class CreateTourUseCase
(
    PasseioDbContext ctx,
    ITourService tourService
)
{
    public async Task<Result<CreateTourResponse>> Do(CreateTourPayload payload)
    {

        var tour = new Tour
        {
            Title = payload.Title,
            Bio = tourService.FormatBio(payload.Bio)
        };

        ctx.Tours.Add(tour);
        await ctx.SaveChangesAsync();

        return Result<CreateTourResponse>.Success(new(tour.ID));
    }
}