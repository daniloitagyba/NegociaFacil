using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegociaFacil.Api.Shared;
using NegociaFacil.Application.Services;
using NegociaFacil.Domain.Identity;
using NegociaFacil.Domain.Shared.Notifications;
using NegociaFacil.Models.User;
using System;
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
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [Authorize(Roles = CustomRoles.Admin)]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioRequestModel requestModel)
        {
            await _identityService.RegisterUser(requestModel);

            if (!NotificationDomainService.IsValid())
                return ResponseData(null, HttpStatusCode.PreconditionFailed);

            return ResponseData(null, HttpStatusCode.NoContent);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel requestModel)
        {
            var response = await _identityService.Login(requestModel);

            if (!NotificationDomainService.IsValid())
                return ResponseData(null, HttpStatusCode.Unauthorized);

            return ResponseData(response, HttpStatusCode.OK);
        }
    }
}
