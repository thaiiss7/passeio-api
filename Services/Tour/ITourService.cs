namespace Passeio.Services.Tour;

public interface ITourService
{
    string FormatBio(string bio);
    Task<string> TagProfiles(string username);
    Task<string> TagPlaces(string stopTitle);
}