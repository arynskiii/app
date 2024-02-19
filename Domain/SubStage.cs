using System.ComponentModel.DataAnnotations.Schema;

namespace Roadmap.Domain;

public class SubStage
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    [ForeignKey(nameof(Stage))]
    public Guid TemplateId { get; set; }
    public Stage Stage { get; set; }
}