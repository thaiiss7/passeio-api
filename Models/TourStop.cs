namespace Passeio.Models;

public class TourStop
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public ICollection<Tour> Tours { get; set; } = [];
}