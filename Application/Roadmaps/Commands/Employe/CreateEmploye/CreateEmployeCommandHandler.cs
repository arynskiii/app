using MediatR;
using Microsoft.AspNetCore.Identity;
using Roadmap.Application.Interfaces;
using Roadmap.Domain;

namespace Roadmap.Application.Roadmaps.Commands.CreateEmploye;

public class CreateEmployeCommandHandler : IRequestHandler<CreateEmployeCommand,string>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    private readonly IRoadmapDbContext _dbContext;

    public CreateEmployeCommandHandler(IRoadmapDbContext dbContext, UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _roleManager = roleManager;
    }

    public async Task<string> Handle(CreateEmployeCommand request, CancellationToken cancellationToken)
    {
       var existingUser= await _userManager.FindByEmailAsync(request.Email);
       if (existingUser == null)
       {
           throw new Exception("Email already exists");
       }

       await _roleManager.CreateAsync(new IdentityRole("Employe"));

       var user = new IdentityUser
       {
           Email = request.Email
       };

       await _userManager.CreateAsync(user, request.Password);
       await _userManager.AddToRoleAsync(user, "Employe");

       var newEmploye = new Domain.Employe
       {
           Email = user.Email,
           Password = request.Password,
           Position = request.Position


       };
      await _dbContext.Employes.AddAsync(newEmploye, cancellationToken);
      await _dbContext.SaveChangesAsync(cancellationToken);

      return "Success";

    }
}