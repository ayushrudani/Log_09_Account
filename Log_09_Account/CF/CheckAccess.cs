using Microsoft.AspNetCore.Mvc.Filters;

namespace Log_09_Account.CF
{
    public class CheckAccess : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var rd = filterContext.RouteData;
            string currentAction = rd.Values["action"].ToString();
            string currentController = rd.Values["controller"].ToString();
            //string currentArea = rd.DataTokens["area"].ToString();

            //if (filterContext.HttpContext.Session.GetInt32("UserID") == null)
            //{
            //    filterContext.Result = new RedirectToActionResult("Index", "SEC_Login", new { Area = "" });
            //}
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            filterContext.HttpContext.Response.Headers["Expires"] = "-1";
            filterContext.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(filterContext);
        }


        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    Controller controller = context.Controller as Controller;

        //    if (controller != null)
        //    {
        //        var rd = context.RouteData;
        //        string currentAction = rd.Values["action"].ToString();
        //        string currentController = rd.Values["controller"].ToString();
        //        string currentArea = rd.Values["area"].ToString();

        //        controller.TempData.Remove("UserOperationRightsModel");
        //        controller.TempData.Add("UserOperationRightsModel", UserOperationRights.CheckForOperation(currentArea, currentController, currentAction));

        //        //controller.TempData.Add("ID", 123);
        //    }
        //}
    }
}
