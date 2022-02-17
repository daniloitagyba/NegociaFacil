using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegociaFacil.Application.Shared;
using NegociaFacil.Domain.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NegociaFacil.Api.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SharedController : ControllerBase
    {
        public INotificationDomainService NotificationDomainService { get; set; }

        protected SharedController(INotificationDomainService notifications)
        {
            NotificationDomainService = notifications ?? throw new ArgumentNullException(nameof(notifications));
        }

        protected IActionResult ResponseData(object result, HttpStatusCode httpStatusCode)
        {
            if (NotificationDomainService == null || NotificationDomainService.IsValid())
            {
                if (httpStatusCode.Equals(HttpStatusCode.Created))
                    return Created("", result);
                else if (httpStatusCode.Equals(HttpStatusCode.OK))
                    return Ok(result);
                else if (httpStatusCode.Equals(HttpStatusCode.NoContent))
                    return NoContent();
                else if (httpStatusCode.Equals(HttpStatusCode.Accepted))
                    return Accepted(result);
            }

            if (httpStatusCode == HttpStatusCode.NotFound)
                return StatusCode(StatusCodes.Status404NotFound,
                                  NotificationDomainService);
            else
            {
                var responseValue = NotificationDomainService?.Notifications.Count > 0 ?
                                    NotificationDomainService :
                                    result;

                return StatusCode(StatusCodes.Status412PreconditionFailed,
                                  responseValue);
            }
        }

        protected IActionResult ResponseData<T>(ResultModel<T> result, HttpStatusCode httpStatusCode)
        {
            if (result != null
                && result.Success
                && (NotificationDomainService == null || NotificationDomainService.IsValid()))
            {
                if (httpStatusCode.Equals(HttpStatusCode.Created))
                    return Created("", result);
                else if (httpStatusCode.Equals(HttpStatusCode.OK))
                    return Ok(result);
                else if (httpStatusCode.Equals(HttpStatusCode.NoContent))
                    return NoContent();
                else if (httpStatusCode.Equals(HttpStatusCode.Accepted))
                    return Accepted(result);
                else if (httpStatusCode == HttpStatusCode.Unauthorized)
                    return StatusCode(StatusCodes.Status401Unauthorized, result);
                else if (httpStatusCode == HttpStatusCode.NotFound)
                    return StatusCode(StatusCodes.Status404NotFound, result);
            }

            if (result?.Success == false)
                return StatusCode(StatusCodes.Status412PreconditionFailed, result);

            return StatusCode(StatusCodes.Status412PreconditionFailed, NotificationDomainService);
        }
    }
}
