using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Shared.Notifications
{
    public class NotificationDomainService : INotificationDomainService
    {
        private List<NotificationItem> _notifications = new List<NotificationItem>();

        public IReadOnlyCollection<NotificationItem> Notifications
        {
            get => _notifications.AsReadOnly();
        }

        public void Add(string code, string value)
        {
            var notificationItem = NotificationItem.Create(code: code, value: value);
            _notifications.Add(notificationItem);
        }

        public void Add(string codeWithValue)
        {
            if (String.IsNullOrEmpty(codeWithValue))
                throw new ArgumentNullException(nameof(codeWithValue));

            var code = codeWithValue.Split("|")?.First();
            var value = codeWithValue.Split("|")?.Last();

            var notificationItem = NotificationItem.Create(code: code, value: value);
            _notifications.Add(notificationItem);
        }

        public bool IsValid()
        {
            return Notifications == null || Notifications.Count == 0;
        }

        public List<string> Get()
        {
            return _notifications?.Select(n => $"{n.Code}-{n.Value}")?.ToList();
        }
    }
}
