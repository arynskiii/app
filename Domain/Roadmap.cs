namespace Roadmap.Domain;

public class Roadmap    
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Category? Category { get; set; }
    public Guid CategoryId { get; set; }
    public List<Stage> Templates { get; set; }
}