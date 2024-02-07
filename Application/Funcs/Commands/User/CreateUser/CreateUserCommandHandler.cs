using MediatR;
using Microsoft.AspNetCore.Identity;
using Roadmap.Application.Interfaces;
using Roadmap.Domain;

namespace Roadmap.Application.Roadmaps.Commands.CreateAdmin;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,Guid>
{
    const string emailAdmin = "admin";
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    
    private readonly IAppDbContext _dbContext;

    public CreateUserCommandHandler(IAppDbContext dbContext, UserManager<User> userManager,
        RoleManager<IdentityRole<Guid>> roleManager) =>
        (_userManager, _roleManager, _dbContext) = (userManager, roleManager, dbContext);

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {   
        
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser!= null)
        {
            throw new Exception("Email already exists");
        }

        await _roleManager.CreateAsync(new  IdentityRole<Guid>("Admin"));
        await _roleManager.CreateAsync(new IdentityRole<Guid>("Employee"));
        
        var user= new User
        {
            Email = request.Email,
            UserName = request.Email
        };
        user.SecurityStamp = Guid.NewGuid().ToString();
       var res= await _userManager.CreateAsync(user, request.Password);
       if (!res.Succeeded)
       {
           throw new Exception(string.Join("\n", res.Errors.Select(e => e.Description)));
       }
        if (request.Email == emailAdmin)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Employee");
            }
       await _dbContext.SaveChangesAsync(cancellationToken);
      
        return user.Id;

    }
}