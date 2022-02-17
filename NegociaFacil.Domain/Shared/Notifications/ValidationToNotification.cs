using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Shared.Notifications
{
    public static class ValidationToNotification
    {
        public static void ToNotification<T>(
           this AbstractValidator<T> validator, T model, INotificationDomainService notificationService)
        {
            ValidationResult results = validator.Validate(model);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    var parts = failure.ErrorMessage.Split('|');
                    if (parts.Length == 2)
                    {
                        var code = parts[0];
                        var errorMessage = parts[1];
                        notificationService.Add(code, errorMessage);
                    }
                    else
                    {
                        notificationService.Add(failure.ErrorCode, failure.ErrorMessage);
                    }
                }
            }
        }
    }
}
