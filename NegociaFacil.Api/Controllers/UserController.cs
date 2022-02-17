using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegociaFacil.Api.Shared;
using NegociaFacil.Application.Models.Login;
using NegociaFacil.Application.Services;
using NegociaFacil.Domain.Shared.Notifications;
using NegociaFacil.Infra.Data.IdentityAuth;
using System.Net;
using System.Threading.Tasks;

namespace NegociaFacil.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SharedController
    {
        private readonly IIdentityService _identityService;
        public UserController(INotificationDomainService notifications,
                                      IIdentityService identityService)
            : base(notifications: notifications)
        {
            _identityService = identityService;
        }

        [Authorize(Roles = CustomRoles.Admin)]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            await _identityService.RegisterUser(registerModel);

            if (!NotificationDomainService.IsValid())
                return ResponseData(null, HttpStatusCode.PreconditionFailed);

            return ResponseData(null, HttpStatusCode.NoContent);
        }

        [Authorize(Roles = CustomRoles.Admin)]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel registerModel)
        {
            await _identityService.RegisterUserAdmin(registerModel);

            if (!NotificationDomainService.IsValid())
                return ResponseData(null, HttpStatusCode.PreconditionFailed);

            return ResponseData(null, HttpStatusCode.NoContent);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel registerModel)
        {
            var response = await _identityService.Login(registerModel);

            if (!NotificationDomainService.IsValid())
                return ResponseData(null, HttpStatusCode.Unauthorized);

            return ResponseData(response, HttpStatusCode.OK);
        }
    }
}
