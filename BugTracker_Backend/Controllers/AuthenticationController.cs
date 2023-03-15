using BugTracker_Backend.Configurations;
using BugTracker_Backend.Data;
using BugTracker_Backend.Models;
using BugTracker_Backend.Models.DTOs;
using BugTracker_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BugTracker_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<BTUser> _userManager;
        private readonly IBTAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<BTUser> userManager,
                                        IBTAuthenticationService authenticationService,
                                        IConfiguration configuration)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestsDto loginRequest)
        { 
            if(ModelState.IsValid)
            {
                //check if user exists
                var user = await _userManager.FindByEmailAsync(loginRequest.Email);

                if(user == null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid Payload"
                        },
                        Result = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

                if (!isCorrect)
                {
                    return BadRequest(new AuthResult()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid credentials"
                        },
                        Result = false
                    });
                }
                       
                var jwtToken = _authenticationService.GenerateJwtToken(user);

                return Ok(new AuthResult()
                {
                    Token= jwtToken,
                    Result = true
                });
            }
           
            else
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Invalid payload"
                    },
                    Result = false
                });
        }



            [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            //validate incoming request
            if (ModelState.IsValid)
            {
                //check if email alredy exists
                var userExists = await _userManager.FindByEmailAsync(requestDto.Email);

                if (userExists != null)
                {
                    return BadRequest(new AuthResult()
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Email already Exists"
                        }
                    });
                }

                //create user
                var newUser = new BTUser
                {
                    UserName = requestDto.UserName,
                    Email = requestDto.Email,
                    FirstName = requestDto.FirstName,
                    LastName = requestDto.LastName,
                    EmailConfirmed = true
                };

                var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

                if (isCreated.Succeeded)
                {
                    //Generate tokens
                    var token = _authenticationService.GenerateJwtToken(newUser);

                    return Ok(new AuthResult()
                    {
                        Result = true,
                        Token = token
                    });
                }

                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>()
                    {
                        "Failed to create"
                    },
                    Result = false
                });
            }
            return BadRequest();
        }
    }
}
