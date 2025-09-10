using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Passeio.Models;

namespace Passeio.UseCases.GetTour;

public class GetTourUseCase(PasseioDbContext ctx)
{
    public async Task<Result<GetTourResponse>> Do(GetTourPayload payload)
    {
        var tour = await ctx.Tours
        .Include(t => t.Author)
            .ThenInclude(a => a.FullName)
        .Include(t => t.TourStops)
            .ThenInclude(s => s.Title)
        .FirstOrDefaultAsync(t => t.Title == payload.Title);

        if (tour is null)
            return Result<GetTourResponse>.Fail("Tour not found");

        var response = new GetTourResponse
        (
            tour.Title,
            tour.Bio,
            from s in tour.TourStops
            select new StopsData
            (
                s.Title
            ),
            tour.Author.FullName
        );

        return Result<GetTourResponse>.Success(response);
    }
}