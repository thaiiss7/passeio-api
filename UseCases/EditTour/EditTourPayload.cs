namespace Passeio.UseCases.EditTour;

public record EditTourPayload
(
    Guid TourId,
    Guid StopId
);