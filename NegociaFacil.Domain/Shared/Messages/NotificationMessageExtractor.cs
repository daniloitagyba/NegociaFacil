using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegociaFacil.Domain.Shared.Messages
{
    public static class NotificationMessageExtractor
    {
        public static string ExtractMessage(this string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;

            var code = message.Split("|")?.First();
            var value = message.Split("|")?.Last();

            return $"{code}-{value}";
        }

        public static string ExtractCode(this string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;
            return message.Split("|")?.First();
        }

        public static IEnumerable<string> ExtractMultipleCodes(
            this IEnumerable<string> messages)
        {
            if (!messages.Any())
                return null;

            return messages.Select(x => x.Split("|")?.First());
        }
    }
}
