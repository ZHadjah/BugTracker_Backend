using BugTracker_Backend.Configurations;
using BugTracker_Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;

namespace BugTracker_Backend.Services.Interfaces
{
    public interface IBTAuthenticationService
    {    
        public string GenerateJwtToken(BTUser user);
    }
}
