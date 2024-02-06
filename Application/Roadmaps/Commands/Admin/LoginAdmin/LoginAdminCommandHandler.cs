using MediatR;
using Microsoft.AspNetCore.Identity;
using Roadmap.Domain;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Roadmap.Application.Common.Helpers;

namespace Roadmap.Application.Roadmaps.Commands.Admin.LoginAdmin;

public class LoginAdminCommandHandler : IRequestHandler<LoginAdminCommand,LoginAdminCommandOutput>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public LoginAdminCommandHandler(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<LoginAdminCommandOutput> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var user =await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }
    
       var signInResult= await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
       if (!signInResult.Succeeded)
       {
           throw new Exception("Invalid Email or Password");
       }

       var roles = await _userManager.GetRolesAsync(user);

   var authToken=   await GenerateToken(user.Email, roles);
   return new LoginAdminCommandOutput
   {
       TokenValue = authToken
   };

    }
    
    private async Task<AuthToken> GenerateToken(string email, IList<string> roles)
    {
        var identity = GetIdentity(email, roles);
        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
            notBefore: now,
            claims:identity.Claims,
            expires:now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials:new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256));
            
        var encodedJWT=new JwtSecurityTokenHandler().WriteToken(jwt);

        var userRole = roles.Contains("Admin") ? "Admin" : "Employe";
        var authToken = new AuthToken
        {
            AccessToken = encodedJWT,
            Email = identity.Name,
            Role = userRole 
        };
        return authToken;
    }
    
    private ClaimsIdentity GetIdentity(string login, IList<string> roles)
    {
        var userRole = roles.Contains("Admin") ? "Admin" : "Employe";

        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, login),
            new Claim(ClaimTypes.Role,userRole)
        };
        
        claims.AddRange(GetRoleClaims(roles));

        ClaimsIdentity claimIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        return claimIdentity;
    }

    private IEnumerable<Claim> GetRoleClaims(IEnumerable<string> roles) => 
        roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();
}
