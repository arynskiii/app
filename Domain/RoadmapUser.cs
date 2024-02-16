namespace Roadmap.Domain;

public class RoadmapUser
{
    public Guid Id { get; set; } 
    public Guid UserId { get; set; } 
    public Guid RoadmapId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}