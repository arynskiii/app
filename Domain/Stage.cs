using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roadmap.Domain;

public class Stage
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid RoadmapId { get; set; }
    public Roadmap Roadmap { get; set; }
    public List<SubStage> SubStages { get; set; }

    public Stage()
    {
        SubStages = new List<SubStage>();
    }
}
