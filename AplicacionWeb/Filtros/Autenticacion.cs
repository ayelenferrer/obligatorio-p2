using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class Autenticacion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string logueado = context.HttpContext.Session.GetString("username");
            if (string.IsNullOrWhiteSpace(logueado))
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { mensaje = "Debe iniciar sesión" });
            }
            base.OnActionExecuting(context);
        }
    }
}
