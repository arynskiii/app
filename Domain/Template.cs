namespace Roadmap.Domain;

public class Template 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid RoadmapId { get; set; }

}