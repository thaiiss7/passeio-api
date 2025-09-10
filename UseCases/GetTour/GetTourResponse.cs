namespace Passeio.UseCases.GetTour;

public record StopsData
(
    string StopTitle
);
public record GetTourResponse
(
    string Title,
    string Bio,
    IEnumerable<StopsData> Stops,
    string AuthorName
);