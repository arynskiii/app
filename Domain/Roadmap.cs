using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roadmap.Domain;

public class Roadmap    
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
   
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Stage> Templates { get; set; }
    public List<RoadmapUser> RoadmapUsers { get; set; }

    public Roadmap()
    {
        Templates = new List<Stage>();
        RoadmapUsers = new List<RoadmapUser>();
    }
}