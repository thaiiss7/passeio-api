namespace Passeio.UseCases.GetTour;

public record StopsData
(
    string StopTitle,
    string AuthorName
);
public record GetTourResponse
(
    string Title,
    string Bio,
    IEnumerable<StopsData> Stops
);