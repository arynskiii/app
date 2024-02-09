namespace Roadmap.Domain;

public class Roadmap
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public string? Filename { get; set; }
    
    public Guid CategoryId { get; set; }
}