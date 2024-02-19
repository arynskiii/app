namespace Roadmap.Domain;

public class FileStatus
{
    public Guid Id { get; set; }
    public string? Filename { get; set; }
    public Guid UserId { get; set; }
    public bool Flag { get; set; }

    public Guid SubTemplateId { get; set; }
}