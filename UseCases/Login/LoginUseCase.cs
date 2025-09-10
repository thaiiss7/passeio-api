using Microsoft.EntityFrameworkCore;
using Passeio.Models;
using Passeio.Services.JWT;

namespace Passeio.UseCases.Login;

public class LoginUseCase
(
    PasseioDbContext ctx,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await ctx.Profiles.FirstOrDefaultAsync(p => p.Username == payload.Username);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        if (user.Password != payload.Password)
            return Result<LoginResponse>.Fail("User not found");

        var jwt = jWTService.CreateToken(new(
            user.ID,
            user.Username
        ));

        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}