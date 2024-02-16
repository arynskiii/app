using System.ComponentModel.DataAnnotations.Schema;

namespace Roadmap.Domain;

public class Sub_Template
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    [ForeignKey(nameof(Template))]
    public Guid TemplateId { get; set; }
    public Template Template { get; set; }
    
    public bool Flag { get; set; }
    
    
    
}