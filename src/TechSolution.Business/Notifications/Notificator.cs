using System.Collections.Generic;
using System.Linq;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;

namespace TechSolution.Business.Notifications
{
    public class Notificator : INotificator
    {
        private List<Notification> _messages;
        public Notificator()
        {
            _messages = new List<Notification>();
        }

        public IEnumerable<Notification> GetMessages()
        {
            return _messages;
        }

        public void Handle(Notification message)
        {
            _messages.Add(message);
        }

        public bool HasNotification()
        {
            return _messages.Any();
        }
    }
}
