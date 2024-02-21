namespace Roadmap.Domain;

public class Category
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    private ICollection<Roadmap> Roadmaps { get; set; }

    public Category()
    {
        Roadmaps = new List<Roadmap>();
    }
}