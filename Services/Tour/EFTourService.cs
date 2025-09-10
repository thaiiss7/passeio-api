
using Passeio.Models;

namespace Passeio.Services.Tour;

public class EFTourService(PasseioDbContext ctx) : ITourService
{
    public string FormatBio(string bio)
    {
        return bio.Replace("  ", " "); 
    }

    public Task<string> TagPlaces(string stopTitle)
    {
        throw new NotImplementedException();
    }

    public Task<string> TagProfiles(string username)
    {
        throw new NotImplementedException();
    }
}