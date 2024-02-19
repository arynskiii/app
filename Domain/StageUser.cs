namespace Roadmap.Domain;

public class StageUser
{
    public Guid Id { get; set; }
   
    public Guid TemplateId { get; set; }
    public RoadmapUser RoadmapUser { get; set; }
    
}