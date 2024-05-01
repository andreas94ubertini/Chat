using ChatApi.Filter;
using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : Controller
    {
        #region Injection
        private readonly UserService _service;

        public AuthController(UserService service)
        {
            _service = service;
        }
        #endregion
        [HttpPost("login")]
        public IActionResult Login(UserLoginModel model)
        {
            // Qui dovresti avere una logica per validare l'utente con il database
            if (_service.LoginUtente(model))
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserType", "USER"),  // Aggiungi il tipo di utente come claim
                    new Claim("Username", model.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "YourIssuer",
                    audience: "YourAudience",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized();
        }

        [HttpGet("user-data")]
        [AuthorizeUserType("USER")]
        public IActionResult GetUserData()
        {
            // Solo gli utenti con tipo "OWNR" possono accedere a questo metodo
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = "Dati sensibili per l'utente"
            });
        }
    }
}
