using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Shared.Notifications
{
    public interface INotificationDomainService
    {
        IReadOnlyCollection<NotificationItem> Notifications { get; }

        void Add(string code, string value);

        void Add(string codeWithValue);

        List<string> Get();

        bool IsValid();
    }
}
