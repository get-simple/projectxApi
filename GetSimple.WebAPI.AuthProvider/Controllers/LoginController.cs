using GetSimple.WebAPI.Seguranca;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetSimple.WebAPI.AuthProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Token(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Login == "admin" && model.Password == "123")
                {
                    var direitos = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("getsimple-webapi-authentication-valid"));
                    var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "GetSimple.WebAPI.AuthProvider",
                        claims: direitos,
                        signingCredentials: credenciais,
                        expires: DateTime.Now.AddMinutes(30)
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenString); //200
                }
                return Unauthorized(); //401
            }
            return BadRequest(); //400
        }
    }
}
