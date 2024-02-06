using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Roadmap.Application.Common.Helpers;

public class AuthOptions
{
    const string KEY = "G+StsRT856hWmZq12e21e12e12e12e12e14t7w";
    public const int LIFETIME = 200;
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}