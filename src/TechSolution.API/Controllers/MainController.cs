using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using TechSolution.Business.Interfaces;
using TechSolution.Business.Models;

namespace TechSolution.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;

        public MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (_notificator.HasNotification())
                return BadRequest(new { Success = false, Errors =  _notificator.GetMessages() });

            return Ok(new { Success = true, Data = result });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(err => err.Errors);

            foreach (var error in errors)
            {
                string message = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                Notify(message);
            }

            return CustomResponse();
        }        

        protected bool IsValidOperation()
        {
            if (_notificator.HasNotification()) return false;

            return true;
        }

        protected void Notify(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }
    }
}
