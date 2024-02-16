namespace Roadmap.Domain;

public class TemplateUser
{
    public Guid Id { get; set; }
   
    public Guid TemplateId { get; set; }
    public RoadmapUser RoadmapUser { get; set; }
    
}