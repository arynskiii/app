using Microsoft.AspNetCore.Identity;

namespace Roadmap.Domain;

public class Admin 
{
    public Guid Id { get; set; }
    public IdentityUser IdentityUser { get; set; }
}