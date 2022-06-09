using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.DTO;
using WebApi.Interface;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

namespace WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUser _IUser;
        public IConfiguration _configuration;

        public LoginController(IConfiguration config, IUser IUser)
        {
            _configuration = config;
            _IUser = IUser;
        }

        [HttpGet("/user")]
        public ActionResult<UserDto> GetUser(string email)
        {
            UserDto? userDto = _IUser.GetUser(email);

            if(userDto != null)
            {
                return userDto;
            }

            return BadRequest();
        }

        [HttpPost("Created/")]
        public IActionResult Created(UserDto userDto)
        {
            if (userDto != null)
            {
                PasswordHasher<UserDto> pw = new PasswordHasher<UserDto>();
                userDto.PassWord = pw.HashPassword(userDto, userDto.PassWord);
                userDto.CreatedDate = DateTime.Now;

                _IUser.Created(userDto);
            }

           return Ok();
        }

        [HttpPost("Login/")]
        public IActionResult Login(LoginDto loginDto)
        {
            UserDto? foundUserDto = _IUser.GetUser(loginDto.Email);

            if(foundUserDto != null)
            {
                PasswordHasher<UserDto> pw = new PasswordHasher<UserDto>();
                if (pw.VerifyHashedPassword(foundUserDto, foundUserDto.PassWord, loginDto.PassWord).Equals(PasswordVerificationResult.Success))
                {
                    if (foundUserDto != null && foundUserDto.Email.Length > 0 && foundUserDto.PassWord.Length > 0)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("Email",foundUserDto.Email)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials: signIn);

                        //return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
                        return CreatedAtAction("Login", new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPatch("UpDateUser/")]
        public IActionResult UpDate(UserDto userdto)
        { 
            if (userdto != null)
            {
                _IUser.Update(userdto);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpDelete("DeleteUser/")]
        public IActionResult Delete(UserDto userdto)
        {
            if (userdto != null)
            {
                _IUser.Delete(userdto);
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
