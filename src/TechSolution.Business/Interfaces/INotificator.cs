using System.Collections.Generic;
using TechSolution.Business.Models;

namespace TechSolution.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        IEnumerable<Notification> GetMessages();
        void Handle(Notification message);
    }
}
