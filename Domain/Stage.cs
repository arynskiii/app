using System.ComponentModel.DataAnnotations.Schema;

namespace Roadmap.Domain;

public class Stage
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    [ForeignKey(nameof(Roadmap))]
    public Guid RoadmapId { get; set; }
    public Roadmap Roadmap { get; set; }
    public List<SubStage> SubStages { get; set; }
}
