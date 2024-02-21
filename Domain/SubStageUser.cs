namespace Roadmap.Domain;

public class SubStageUser
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }       
    public Guid SubStageId { get; set; }
    public SubStage SubStage { get; set; }
   
    
}