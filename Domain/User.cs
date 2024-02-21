using Microsoft.AspNetCore.Identity;

namespace Roadmap.Domain;

public class User : IdentityUser<Guid>
{
    public List<SubStageUser> SubStageUsers { get; set; }
    public List<RoadmapUser> RoadmapsUsers;
    public List<FileStatus> FileStatusList { get; set; }
    public User()
    {
        SubStageUsers = new List<SubStageUser>();
        RoadmapsUsers = new List<RoadmapUser>();
        FileStatusList = new List<FileStatus>();
    }
    
}
