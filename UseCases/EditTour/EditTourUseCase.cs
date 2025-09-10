using Microsoft.EntityFrameworkCore;
using Passeio.Models;

namespace Passeio.UseCases.EditTour;

public class EditTourUseCase(PasseioDbContext ctx)
{
    public async Task<Result<EditTourResponse>> Do(EditTourPayload payload)
    {
        var tour = await ctx.Tours.FirstOrDefaultAsync(t => t.ID == payload.TourId);

        if (tour is null)
            return Result<EditTourResponse>.Fail("Tour not found");

        if (tour.ProfileId != payload.UserId)
            return Result<EditTourResponse>.Fail("You are not the owner of this Tour");

        var stop = await ctx.TourStops.FirstOrDefaultAsync(s => s.ID == payload.StopId);

        if (stop is null)
            return Result<EditTourResponse>.Fail("Stop not found");

        tour.TourStops.Add(stop);
        await ctx.SaveChangesAsync();
        return Result<EditTourResponse>.Success(null);
    }
}