using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roadmap.Domain;

public class RoadmapUser
{
    public Guid Id { get; set; } 
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid RoadmapId { get; set; }
    public Roadmap Roadmap { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}