using System.Collections.Generic;

namespace Passeio.Models;

public class Tour
{
    public Guid ID { get; set; }
    public string Title { get; set; }
    public string Bio { get; set; }
    public ICollection<TourStop> TourStops { get; set; }
    public Profile Author { get; set; }
    public Guid ProfileId { get; set; }
}