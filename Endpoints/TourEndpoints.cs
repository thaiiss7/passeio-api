using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Passeio.Data;
using Passeio.UseCases.CreateTour;
using Passeio.UseCases.EditTour;
using Passeio.UseCases.GetTour;

namespace Passeio.Endpoints;

public static class TourEndpoints
{
    public static void ConfigureTourEndpoints(this WebApplication app)
    {
        //mappost - criar tour
        app.MapPost("tour", async (
            [FromBody] CreateTourPayload payload,
            [FromServices] CreateTourUseCase useCase) =>
            {
                var result = await useCase.Do(payload);

                if (!result.isSuccess)
                    return Results.BadRequest(result.Reason);

                return Results.Created();
            });

        //mapput - editar tour
        app.MapPut("/edit", async (
            HttpContext http,
            [FromBody] EditTourData payload,
            [FromServices] EditTourUseCase useCase) =>
            {
                var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
                var userId = Guid.Parse(claim.Value);

                var result = await useCase.Do(new EditTourPayload(
                    payload.tourId,
                    payload.stopId,
                    userId
                ));

                return (result.isSuccess, result.Reason) switch
                {
                    (false, "Tour or Stop not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
                
            }).RequireAuthorization();

        //mapget - ver tour
        app.MapGet("tour/{title}", async (
            string title,
            [FromServices] GetTourUseCase useCase) =>
            {
                var payload = new GetTourPayload(title);
                var result = await useCase.Do(payload);

                return (result.isSuccess, result.Reason) switch
                {
                    (false, "Tour not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };
            });
    }
}