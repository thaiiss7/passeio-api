using Microsoft.AspNetCore.Mvc;
using Passeio.UseCases.Login;

namespace Passeio.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("auth", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase UseCase) =>
            {
                var result = await UseCase.Do(payload);
                if (!result.isSuccess)
                    return Results.BadRequest();

                return Results.Ok(result.Data);
            });
            
    }

}