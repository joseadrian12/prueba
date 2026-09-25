using CineApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var usuario =
                await _userManager
                    .FindByNameAsync(login.Usuario);

            if (usuario == null)
            {
                return Unauthorized(
                    "Usuario o contraseña incorrectos"
                );
            }


            var passwordValido =
                await _userManager
                    .CheckPasswordAsync(
                        usuario,
                        login.Password
                    );

            if (!passwordValido)
            {
                return Unauthorized(
                    "Usuario o contraseña incorrectos"
                );
            }


            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    usuario.Id
                ),

                new Claim(
                    ClaimTypes.Name,
                    usuario.UserName!
                )
            };


            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration["Jwt:Key"]!
                )
            );


            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                );


            var token = new JwtSecurityToken(
                issuer:
                    _configuration["Jwt:Issuer"],

                audience:
                    _configuration["Jwt:Audience"],

                claims: claims,

                expires:
                    DateTime.Now.AddHours(2),

                signingCredentials:
                    credentials
            );


            var tokenString =
                new JwtSecurityTokenHandler()
                    .WriteToken(token);


            return Ok(
                new LoginResponseDto
                {
                    Token = tokenString,
                    Usuario = usuario.UserName!
                }
            );
        }

    }
}
