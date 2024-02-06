using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Roadmap.Application.Common.Helpers;

public class AuthOptions
{
    const string KEY = "G+StsRT856hWmZq4t7w";
    public const int LIFETIME = 200;
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}