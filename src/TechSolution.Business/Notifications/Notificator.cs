using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;

namespace TechSolution.Business.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _messages;
        private ILogger<Notificator> _logger;

        public Notificator(ILogger<Notificator> logger)
        {
            _messages = new List<Notification>();
            _logger = logger;
        }

        public IEnumerable<Notification> GetMessages()
        {
            return _messages;
        }

        public void Handle(Notification message)
        {
            _logger.LogInformation(message.Message);
            _messages.Add(message);
        }

        public bool HasNotification()
        {
            return _messages.Any();
        }
    }
}
