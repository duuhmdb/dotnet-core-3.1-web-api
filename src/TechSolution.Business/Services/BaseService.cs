using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;

namespace TechSolution.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}
