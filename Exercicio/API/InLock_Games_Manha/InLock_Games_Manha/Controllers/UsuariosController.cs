using InLock_Games_Manha.Domains;
using InLock_Games_Manha.Interfaces;
using InLock_Games_Manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InLock_Games_Manha.Controllers
{
    [Produces("application/Json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository { get; set; }

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuariosDomain login)
        {
            UsuariosDomain usuarios = _usuariosRepository.Login(login.Email, login.Senha);

            if (usuarios == null)
            {
                return NotFound("Email ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarios.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarios.IdUsuarios.ToString()),
                new Claim(ClaimTypes.Role, usuarios.IdTipoUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-Chave-Autentificacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "InLockGames",
                audience: "InLockGames",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
