using BugTracker_Backend.Configurations;
using BugTracker_Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BugTracker_Backend.Services.Interfaces
{
    public interface IBTAuthenticationService
    {    
        string GenerateJwtToken(BTUser user);
        IEnumerable<Claim> ValidateToken(string authToken, string secretKey);
    }
}
