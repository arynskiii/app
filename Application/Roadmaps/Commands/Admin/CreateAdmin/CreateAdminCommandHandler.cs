using MediatR;
using Microsoft.AspNetCore.Identity;
using Roadmap.Application.Interfaces;

namespace Roadmap.Application.Roadmaps.Commands.CreateAdmin;

public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand,Guid>
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    private readonly IRoadmapDbContext _dbContext;

    public CreateAdminCommandHandler(IRoadmapDbContext dbContext, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager) =>
        (_userManager, _roleManager, _dbContext) = (userManager, roleManager, dbContext);

    public async Task<Guid> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var User = await _userManager.FindByEmailAsync(request.Email);
        if (User == null)
        {
            throw new Exception("Email already exists");
        }

        await _roleManager.CreateAsync(new IdentityRole("Admin"));
        
        
        var user = new IdentityUser
        {
            Email = request.Email
            
        };
        await _userManager.CreateAsync(user, request.Password);
        await _userManager.AddToRoleAsync(user, "Admin");

        var newAdmin = new Domain.Admin()
        {
           IdentityUser = user

        };
        await _dbContext.Admins.AddAsync(newAdmin,cancellationToken);
        
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        Guid userId = Guid.Parse(user.Id);
        return userId;

    }
}