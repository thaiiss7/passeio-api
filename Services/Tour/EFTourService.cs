
using Passeio.Models;

namespace Passeio.Services.Tour;

public class EFTourService(PasseioDbContext ctx) : ITourService
{
    public string FormatBio(string bio)
        => bio.Replace("  ", " "); 


    public string TagPlaces(string stopTitle)
    {
        throw new NotImplementedException();
    }

    public string TagProfiles(string username)
    {
        throw new NotImplementedException();
    }
}