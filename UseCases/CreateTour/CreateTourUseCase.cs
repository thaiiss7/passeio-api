using Passeio.Models;

namespace Passeio.UseCases.CreateTour;

public class CreateTourUseCase(PasseioDbContext ctx)
{
    public async Task<Result<CreateTourResponse>> Do(CreateTourPayload payload)
    {
        var tour = new Tour
        {
            Title = payload.Title,
            Bio = payload.Bio
        };

        ctx.Tours.Add(tour);
        await ctx.SaveChangesAsync();

        return Result<CreateTourResponse>.Success(new(tour.ID));
    }
}