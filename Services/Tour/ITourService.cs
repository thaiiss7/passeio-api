namespace Passeio.Services.Tour;

public interface ITourService
{
    string FormatBio(string bio);
    string TagProfiles(string username);
    string TagPlaces(string stopTitle);
}