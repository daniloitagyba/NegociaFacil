using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NegociaFacil.Application.Options.Jwt;
using NegociaFacil.Domain.Identity;
using NegociaFacil.Domain.Shared.Messages;
using NegociaFacil.Domain.Shared.Notifications;
using NegociaFacil.Models.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Application.Services.Abstractions
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INotificationDomainService _notificationDomainService;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(UserManager<ApplicationUser> userManager,
                               INotificationDomainService notificationDomainService,
                               IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _notificationDomainService = notificationDomainService;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            var user = await _userManager.FindByNameAsync(requestModel.NomeUsuario);
            if (user == null || !await _userManager.CheckPasswordAsync(user, requestModel.Senha))
            {
                _notificationDomainService.Add(NotificationMessages._00001_Usuario_Senha_Invalido);
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = GetClaimList(user);

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            var token = GetJwtSecurityToken(authClaims, authSigningKey);

            return new LoginResponseModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        private JwtSecurityToken GetJwtSecurityToken(List<Claim> authClaims, SymmetricSecurityKey authSigningKey)
        {
            return new JwtSecurityToken(
                issuer: _jwtOptions.ValidIssuer,
                audience: _jwtOptions.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        }

        private static List<Claim> GetClaimList(ApplicationUser user)
        {
            return new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
        }

        public async Task RegisterUser(UsuarioRequestModel requestModel)
        {
            var userExists = await _userManager.FindByNameAsync(requestModel.NomeUsuario);
            if (userExists != null)
            {
                _notificationDomainService.Add(NotificationMessages._00002_Usuario_Existe);
                return;
            }

            var user = GetApplicationUser(requestModel);

            var result = await _userManager.CreateAsync(user, requestModel.Senha);
            if (!result.Succeeded)
            {
                _notificationDomainService.Add($"{NotificationMessages._00003_Erro_Criar_Usuario} {result}");
                return;
            }

            if (requestModel.Administrador)
                await _userManager.AddToRoleAsync(user, CustomRoles.Admin);
        }

        private static ApplicationUser GetApplicationUser(UsuarioRequestModel requestModel)
        {
            return new ApplicationUser()
            {
                Email = requestModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = requestModel.NomeUsuario
            };
        }
    }
}
