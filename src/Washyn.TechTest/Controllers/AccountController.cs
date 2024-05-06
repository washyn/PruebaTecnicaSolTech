using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Security.Encryption;
using Washyn.TechTest.Entities;
using Washyn.TechTest.Models;
using Washyn.TechTest.Others;
using Washyn.TechTest.Repositories;

namespace Washyn.TechTest.Controllers
{
    [AllowAnonymous]
    [Route("api/app/account")]
    public class AccountController : AbpControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IStringEncryptionService _encryptionService;
        private readonly JwtBearer _options;

        public AccountController(IOptions<JwtBearer> options, IUsuarioRepository usuarioRepository, IStringEncryptionService encryptionService)
        {
            _usuarioRepository = usuarioRepository;
            _encryptionService = encryptionService;
            _options = options.Value;
        }
        
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<LoginOutput> Post([FromBody] LoginInput model)
        {
            var user = await _usuarioRepository.GetAsync(a => a.UserName == model.User);
            var passEnc = _encryptionService.Encrypt(model.Password);
            var checkPasswordResult = string.Equals(user.Password ,passEnc, StringComparison.Ordinal);
            if (checkPasswordResult)
            {
                return new LoginOutput()
                {
                    AccessToken = CreateAccessToken(user)
                };
            }
            throw new UserFriendlyException("Check user or passsword.");
        }
        
        [Authorize]
        [Route("logout")]
        [HttpPost]
        public async Task Post([FromBody] LoginOutput model)
        {
            await HttpContext.SignOutAsync(JwtBearerDefaults.AuthenticationScheme);
        }

        private string CreateAccessToken(Usuario user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimConsts.Id, user.Id.ToString()));
            claims.Add(new Claim(ClaimConsts.UserName, user.UserName));
            claims.Add(new Claim(ClaimConsts.Name, user.Name));
            claims.Add(new Claim(ClaimConsts.Email, user.Email));
            claims.Add(new Claim(ClaimConsts.SurName, user.Surname));

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecurityKey));
            var siginCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(issuer: _options.Issuer, audience: _options.Audience,
                claims: claims, expires: DateTime.Now.AddHours(8), signingCredentials: siginCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}