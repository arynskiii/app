namespace Roadmap.Domain;

public class Template : Roadmap
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid RoadmapId { get; set; }

}