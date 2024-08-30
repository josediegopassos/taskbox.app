using Microsoft.AspNetCore.Mvc;
using TaskBox.Domain.Interfaces;
using TaskBox.Domain.Notifications;

namespace TaskBox.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IHandler<DomainNotification> Notifications { get; }

        protected bool IsValidOperation() => Notifications == null || !Notifications.HasNotifications();

        protected ActionResult ResponsePutPatch()
        {
            if (IsValidOperation())
            {
                return NoContent();
            }

            return ResponseBadRequest();
        }

        protected ActionResult ResponseDelete()
        {
            if (IsValidOperation())
            {
                return NoContent();
            }

            return ResponseBadRequest();
        }

        protected ActionResult ResponseBadRequest()
        {
            if (Notifications != null)
            {
                return BadRequest(new ValidationProblemDetails(Notifications.GetNotificationsByKey()));
            }

            return BadRequest();
        }

        protected ActionResult<T> ResponsePost<T>(T result)
        {
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        protected ActionResult<IEnumerable<T>> ResponseGet<T>(IEnumerable<T> result)
        {

            if (result == null || (result != null && !result.Any()))
                return NotFound();

            return Ok(result);
        }

        protected ActionResult<T> ResponseGet<T>(T result)
        {
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
